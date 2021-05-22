using AutoMapper;
using CB.Data.Data;
using CB.Infrastructure.Services.Auction;
using CB.Infrastructure.Services.User;
using CB.Infrastructure.Utility;
using CB.Models.DTOs.Client;
using CB.Models.DTOs.Helpers;
using CB.Models.Entities.Auth;
using CB.Models.Exceptions;
using CB.Models.Resources;
using CB.Models.ViewModels.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Client
{
    public class ClientService : IClientService
    {

        private readonly CBDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAuctionService _auctionService;

        public ClientService(CBDbContext context, IMapper mapper, IUserService userService, IAuctionService auctionService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _auctionService = auctionService;
        }

        public async Task<ClientUpdateDto> Get(int id)
        {
            var data = await _context.Users.Include(x => x.Client).FirstOrDefaultAsync(x => x.ClientId == id);
            if (data == null || data.IsDelete || data.Client == null)
            {
                throw new CBErrorException(MessageResource.ItemNotFound);
            }
            return new ClientUpdateDto
            {
                Id = data.Client.Id,
                Bio = data.Client.Bio,
                Email = data.Email,
                FullName = data.FullName,
                Image = data.Client.Image,
                IsActive = data.IsActive,
                PhoneNumber = data.PhoneNumber,
                UserName = data.Client.UserName
            };
        }
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _context.Users.Include(x => x.Client).Where(x => !x.IsDelete &&
             x.UserType == Models.Enums.UserType.Client
             && (string.IsNullOrEmpty(query.GeneralSearch)
             || query.GeneralSearch.Contains(x.FullName)));
            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage)
                .Select(x => new ClientVm
                {
                    Id = x.ClientId.Value,
                    CreatedAt = x.Client.CreatedAt.HasValue ? x.Client.CreatedAt.Value.ToString("dd/MM/yyyy") : "---",
                    Email = x.Email,
                    FullName = x.FullName,
                    IsActive = x.IsActive,
                    PhoneNumber = x.PhoneNumber,
                    UserName = x.Client.UserName,
                    Image = x.Client.Image,
                }).ToListAsync();
            var pages = pagination.GetPages(dataCount);
            return new ResponseDto
            {
                data = dataList,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
        }
        public async Task Create(ClientCreateDto input, string userId)
        {
            var isExsist = await _context.Clients.AnyAsync(x => x.UserName.Equals(input.UserName));
            if (isExsist)
                throw new CBErrorException(MessageResource.UserNameAreadyExsist);
            var user = _mapper.Map<CBUser>(input);
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = userId;
            user.CreatedAt = DateTime.Now;
            user.CreatedBy = userId;
            user.UserType = Models.Enums.UserType.Client;
            user.UserName = input.Email;
            var result = await _userService.Create(user, input.Password);
            if (!result)
                throw new CBErrorException(MessageResource.GeneralError);
            var client = new CB.Models.Entities.Client.Client
            {
                UserName = input.UserName,
                Image = input.Image,
                Bio = input.Bio,
                OwnerId = user.Id,
                CreatedAt = user.CreatedAt,
                CreatedBy = user.CreatedBy,
            };
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            user.ClientId = client.Id;
            await _context.SaveChangesAsync();
        }
        public async Task Update(ClientUpdateDto input, string userId)
        {
            var isExsist = await _context.Clients
                .AnyAsync(x => x.UserName.Equals(input.UserName) && x.Id != input.Id);
            if (isExsist)
                throw new CBErrorException(MessageResource.UserNameAreadyExsist);
            var user = await _context.Users.Include(x => x.Client)
                .FirstOrDefaultAsync(x => x.ClientId == input.Id);
            if (user == null || user.IsDelete)
                throw new CBErrorException(MessageResource.ItemNotFound);
            user.FullName = input.FullName;
            user.UserName = input.UserName;
            user.Email = input.Email;
            user.PhoneNumber = input.PhoneNumber;
            user.IsActive = input.IsActive;
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = userId;
            user.Client.UserName = input.UserName;
            user.Client.Bio = input.Bio;
            user.Client.Image = input.Image;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id, string userId)
        {
            var user = await _context.Users.Include(x => x.Client)
                .FirstOrDefaultAsync(x => x.ClientId == id);
            if (user == null || user.IsDelete)
                throw new CBErrorException(MessageResource.ItemNotFound);
            user.IsDelete = true;
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = userId;
            user.Client.IsDelete = true;
            user.Client.UpdatedAt = DateTime.Now;
            user.Client.UpdatedBy = userId;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

        }
        public async Task<ClientProfileVm> GetProfile(int id)
        {
            var client = await _context.Users.Include(x => x.Client)
                .FirstOrDefaultAsync(x => x.ClientId == id);
            if (client == null || client.Client == null)
                throw new CBErrorException(MessageResource.ItemNotFound);
            var totalAuctions = await _context.Auctions.CountAsync(x => x.SellerId == id);
            var totalSoldAuctions = await _context.Auctions.CountAsync(x => x.SellerId == id && x.Status == Models.Enums.AuctionStatus.Sold);
            var totalPurchaseAuctions = await _context.Auctions.CountAsync(x => x.BayerId == id && x.Status == Models.Enums.AuctionStatus.Sold);
            var totalBids = await _context.Bids.CountAsync(x => x.ClientId == id);
            var totalComments = await _context.Comments.CountAsync(x => x.ClientId == id);
            var totalCommentLike = await _context.CommentLike.CountAsync(x => x.ClientId == id);
            return new ClientProfileVm
            {
                FullName = client.FullName,
                Bio = client.Client.Bio,
                Email = client.Email,
                Id = client.ClientId.Value,
                Image = client.Client.Image,
                UserName = client.Client.UserName,
                LastLogin = client.LastLogin.HasValue ? client.LastLogin.Value.ToString("dd/MM/yyyy : hh:mm:ss") : "-",
                PhoneNumber = client.PhoneNumber,
                IsRegisterAsBider = client.Client.IsBidder,
                TotalAuctions = totalAuctions,
                TotalBids = totalBids,
                TotalComments = totalComments,
                TotalSold = totalSoldAuctions,
                TotalPurchased = totalPurchaseAuctions,
                TotalLikes = totalCommentLike,
                IsActive = client.IsActive,
            };
        }
        public async Task<ResponseDto> GetAllAuctions(int id, Pagination pagination, Query query)
        {
            return await _auctionService.GetAll(pagination, query, id);
        }

    }
}
