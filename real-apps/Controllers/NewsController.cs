using Microsoft.AspNetCore.Mvc;

namespace real_apps.Controllers
{
  [Route("news")]
  public class NewsController : Controller
  {
    [Route("index")]
    public IActionResult Index()
    {
      return View();
    }

  }
}