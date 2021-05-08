using CB.Infrastructure.Services.Auth;
using CB.Models.DTOs.Auth;
using CB.Models.Entities.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private string returnUrl;
        private readonly IAuthWebService _authService;


        public AuthController(IAuthWebService authService)
        {
            returnUrl = "/";
            _authService = authService;
        }

        public IActionResult Login(string returnUrl)
        {
            this.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto input)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Login(input);
                if (result)
                {
                    return LocalRedirect(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(input);
        }
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return LocalRedirect(returnUrl);
        }

    }
}
