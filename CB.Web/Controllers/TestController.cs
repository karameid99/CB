using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Web.Controllers
{

    public class TestController : BaseController
    {
        [HttpGet]
        public IActionResult Test1()
        {
            return GetResponse();
        }
    }
}
