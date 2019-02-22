using Microsoft.AspNetCore.Mvc;

namespace real_apps.Areas.Admin.Controllers
{
  [Area("admin")]
  [Route("admin/home")]
  public class HomeController : Controller
  {
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
      return View();
    }
  }
}