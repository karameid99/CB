using CB.Infrastructure.Services.LookUp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Web.Controllers
{
    public class LookUpController : BaseController
    {
        private readonly ILookUpService _lookUpService;

        public LookUpController(ILookUpService lookUpService)
        {
            _lookUpService = lookUpService;
        }
        public IActionResult GetPermission()
        {
            return Ok(_lookUpService.GetPermission());
        }

        public async Task<IActionResult> GetRoles()
        {
            return Json(await _lookUpService.GetRole());
        }
    }
}
