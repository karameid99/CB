using CB.Models.Models;
using CB.Models.Resources;
using CB.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CB.Web.Controllers
{
    [Authorize]
    [AuthFilter]
    public class BaseController : Controller
    {
        protected string GetCurrntUserId()
        {
            return ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "UserId")?.Value ?? "";
        }
    }

}
