using Microsoft.AspNetCore.Mvc;


namespace CB.Web.Controllers
{

    public class TestController : BaseController
    {
        [HttpGet]
        public IActionResult Test()
        {
            return GetResponse();
        }
    }
}
