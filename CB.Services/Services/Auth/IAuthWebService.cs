using CB.Models.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Auth
{
    public interface IAuthWebService
    {
        Task<bool> Login(LoginDto input);
        Task Logout();
        Task<ClaimsPrincipal> AddUserTypeClaim(ClaimsPrincipal principal);
    }
}
