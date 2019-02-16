using Microsoft.AspNetCore.Mvc;

namespace real_apps.Controllers
{
    [Route("demo")]
    public class DemoController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("demo2")]
        public IActionResult Demo2()
        {
            return View("Demo2");
        }
    }
}