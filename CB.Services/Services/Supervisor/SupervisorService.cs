using AutoMapper;
using CB.Data.Data;
using CB.Infrastructure.Utility;
using CB.Models.DTOs.Helpers;
using CB.Models.DTOs.Supervisor;
using CB.Models.Entities.Auth;
using CB.Models.ViewModels.Supervisor;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Supervisor
{
    public class SupervisorService : ISupervisorService
    {
        private readonly CBDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<CBUser> _userManager;

        public SupervisorService(CBDbContext context, IMapper mapper, UserManager<CBUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<SupervisorUpdateDto> Get(string id)
        {
            var data = await _context.Users.FindAsync(id);
            if (data == null || data.IsDelete)
            {

            }
            return _mapper.Map<SupervisorUpdateDto>(data);
        }
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = pagination.GetSkipValue();
            var queryString = _context.Users.Where(x => !x.IsDelete &&
            x.UserType == Models.Enums.UserType.Supervisor
            && (string.IsNullOrEmpty(query.GeneralSearch)
            || query.GeneralSearch.Contains(x.FullName)));
            var dataCount = queryString.Count();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage)
                .Select(x => new SupervisorVm
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
        public async Task Create(SupervisorCreateDto input, string userId)
        {
            var user = _mapper.Map<CBUser>(input);
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = userId;
            user.CreatedAt = DateTime.Now;
            user.CreatedBy = userId;
            user.UserType = Models.Enums.UserType.Supervisor;
            user.UserName = input.Email;
            var result = await _userManager.CreateAsync(user, input.Password);
            if (!result.Succeeded)
            {

            }
        }
        public async Task Update(SupervisorUpdateDto input, string userId)
        {
            var user = await _context.Users.FindAsync(input.Id);
            if (user == null || user.IsDelete)
            {

            }
            user.FullName = input.FullName;
            user.Email = input.Email;
            user.PhoneNumber = input.PhoneNumber;
            user.IsActive = input.IsActive;
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = userId;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(string id, string userId)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user.IsDelete)
            {

            }
            user.IsDelete = true;
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = userId;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

        }

    }
}
