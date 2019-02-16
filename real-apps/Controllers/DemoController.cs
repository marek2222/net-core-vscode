using Microsoft.AspNetCore.Mvc;

namespace real_apps.Controllers
{
  public class DemoController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}