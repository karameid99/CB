using AutoMapper;
using CB.Data.Data;
using CB.Infrastructure.Utility;
using CB.Models.DTOs.Helpers;
using CB.Models.DTOs.Role;
using CB.Models.Entities.Auth;
using CB.Models.ViewModels.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly CBDbContext _context;
        private readonly IMapper _mapper;

        public RoleService(CBDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoleUpdateDto> Get(int id)
        {
            var data = await _context.Role.FindAsync(id);
            if (data == null || data.IsDelete)
            {

            }
            return _mapper.Map<RoleUpdateDto>(data);
        }
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = pagination.GetSkipValue();
            var queryString = _context.Role.Where(x => !x.IsDelete
            && (string.IsNullOrEmpty(query.GeneralSearch)
            || query.GeneralSearch.Contains(x.NameAr)) || query.GeneralSearch.Contains(x.NameAr));
            var dataCount = queryString.Count();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage)
                .Select(x => new RoleVm
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt.HasValue ? x.CreatedAt.Value.ToString("dd/MM/yyyy") : "---",
                    NameAr = x.NameAr,
                    NameEn = x.NameEn,
                    Permissions = x.Permission,
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
        public async Task Create(RoleCreateDto input, string userId)
        {
            var role = _mapper.Map<CB.Models.Entities.Auth.Role>(input);
            role.UpdatedAt = DateTime.Now;
            role.UpdatedBy = userId;
            role.CreatedAt = DateTime.Now;
            role.CreatedBy = userId;
            await _context.Role.AddAsync(role);
            await _context.SaveChangesAsync();
        }
        public async Task Update(RoleUpdateDto input, string userId)
        {
            var role = await _context.Role.FindAsync(input.Id);
            if (role == null || role.IsDelete)
            {

            }
            role.NameAr = input.NameAr;
            role.NameEn = input.NameEn;
            role.Permission = input.Permission;
            role.UpdatedAt = DateTime.Now;
            role.UpdatedBy = userId;
            _context.Role.Update(role);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id, string userId)
        {
            var role = await _context.Role.FindAsync(id);
            if (role == null || role.IsDelete)
            {

            }
            role.IsDelete = true;
            role.UpdatedAt = DateTime.Now;
            role.UpdatedBy = userId;
            _context.Role.Update(role);
            await _context.SaveChangesAsync();

        }

    }
}
