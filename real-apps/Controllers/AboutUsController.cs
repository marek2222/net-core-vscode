using Microsoft.AspNetCore.Mvc;

namespace real_apps.Controllers
{
  [Route("aboutus")]
  public class AboutUsController : Controller
  {
    [Route("index")]
    public IActionResult Index()
    {
      return View();
    }

  }
}