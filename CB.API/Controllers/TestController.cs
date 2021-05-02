using Microsoft.AspNetCore.Mvc;


namespace CB.API.Controllers
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
