using CB.Models.DTOs.Helpers;
using CB.Models.DTOs.User;
using CB.Models.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.User
{
    public interface IUserService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<UserUpdateDto> Get(string id);
        Task<bool> Create(CBUser input, string password);
        Task Update(CBUser input);
    }
}
