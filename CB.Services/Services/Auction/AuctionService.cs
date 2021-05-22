using AutoMapper;
using CB.Data.Data;
using CB.Infrastructure.Utility;
using CB.Models.DTOs.Auction;
using CB.Models.DTOs.Helpers;
using CB.Models.ViewModels.Auction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Auction
{
    public class AuctionService : IAuctionService
    {
        private readonly CBDbContext _context;
        private readonly IMapper _mapper;

        public AuctionService(CBDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(AuctionCreateDto input, string userId)
        {
            var auction = _mapper.Map<CB.Models.Entities.Car.Auction>(input);
            auction.CreatedBy = userId;
            await _context.AddAsync(auction);
            await _context.SaveChangesAsync();
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query, int? id = null)
        {
            var queryString = _context.Auctions.Include(x => x.Seller)
                .Include(x => x.Bids)
                .Include(x => x.Comment)
                .Where(x => !x.IsDelete
                && (string.IsNullOrEmpty(query.GeneralSearch)
                || query.GeneralSearch.Contains(x.SellerName)));
            if (id.HasValue)
                queryString = queryString.Where(x => x.SellerId == id.Value);
            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage)
                .Select(x => new AuctionProfileVm
                {
                    Id = x.Id,
                    SellerName = x.SellerName,
                    Bids = x.Bids.Count(),
                    Comments = x.Comment.Count(),
                    Status = x.Status,
                    SellerPhone = x.SellerPhone,
                    CreatedAt = x.CreatedAt.HasValue ? x.CreatedAt.Value.ToString("dd/MM/yyyy") : "---",
                    EndingAt = x.EndingAt.HasValue ? x.EndingAt.Value.ToString("dd/MM/yyyy\n hh:mm") : "---"
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
    }
}
