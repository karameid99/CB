using CB.Data.Data;
using CB.Models.DTOs.Auth;
using CB.Models.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Auth
{
    public class AuthWebService : IAuthWebService
    {
        private readonly UserManager<CBUser> _userManager;
        private readonly SignInManager<CBUser> _signInManager;
        private readonly CBDbContext _context;

        public AuthWebService(UserManager<CBUser> userManager, SignInManager<CBUser> signInManager, CBDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<bool> Login(LoginDto input)
        {
            var user = await _context.Users.Include(x=> x.Role).FirstOrDefaultAsync(x => x.UserName == input.Email);
            if (user == null)
            {

            }
            var claims = new List<Claim>(){
                new Claim("UserId", user.Id),
                new Claim("UserType",user.UserType.ToString() ) ,
                new Claim("Permissions",user.Role.Permission) };
            await _signInManager.SignInWithClaimsAsync(user, true, claims);
            return true;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<ClaimsPrincipal> AddUserTypeClaim(ClaimsPrincipal principal)
        {
            // Clone current identity
            var clone = principal.Clone();
            var newIdentity = new ClaimsIdentity();

            // Support AD and local accounts
            var nameId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == ClaimTypes.Name);
            if (nameId == null)
            {
                return principal;
            }
            // Get user from database
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                return principal;
            }

            // Add role claims to cloned identity
            var claim = new Claim(newIdentity.RoleClaimType, user.UserType.ToString());
            newIdentity.AddClaim(claim);
            return clone;
        }
    }
}
