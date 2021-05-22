using AutoMapper;
using CB.Data.Data;
using CB.Infrastructure.Utility;
using CB.Models.DTOs.Helpers;
using CB.Models.DTOs.User;
using CB.Models.Entities.Auth;
using CB.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly CBDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<CBUser> _userManager;

        public UserService(CBDbContext context, IMapper mapper, UserManager<CBUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserUpdateDto> Get(string id)
        {
            var data = await _context.Users.FindAsync(id);
            if (data == null || data.IsDelete)
            {

            }
            return _mapper.Map<UserUpdateDto>(data);
        }
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = pagination.GetSkipValue();
            var queryString = _context.Users
                .Where(x => !x.IsDelete 
            && (string.IsNullOrEmpty(query.GeneralSearch)
            || query.GeneralSearch.Contains(x.FullName)));
            var dataCount = queryString.Count();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage)
                .Select(x => new UserVm
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt.HasValue ? x.CreatedAt.Value.ToString("dd/MM/yyyy") : "---",
                    Email = x.Email,
                    FullName = x.FullName,
                    IsActive = x.IsActive,
                    PhoneNumber = x.PhoneNumber,
                    LastLogin = x.LastLogin.HasValue ? x.LastLogin.Value.ToString("dd/MM/yyyy") : "---",
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
        public async Task<bool> Create(CBUser user, string password)
        {
           
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }
        public async Task Update(CBUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
       

    }
}
