using CB.Models.DTOs.Helpers;
using CB.Models.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Role
{
   public interface IRoleService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<RoleUpdateDto> Get(int id);
        Task Create(RoleCreateDto input, string userId);
        Task Update(RoleUpdateDto input, string userId);
        Task Delete(int id, string userId);
    }
}
