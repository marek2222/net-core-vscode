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

    [Route("demo2/{id}")]
    public IActionResult Demo2(int id)
    {
      ViewBag.id = id;
      return View("Demo2");
    }

    [Route("demo3/{id1}/{id2}")]
    public IActionResult Demo3(int id1, string id2)
    {
      ViewBag.id1 = id1;
      ViewBag.id2 = id2;
      return View("Demo3");
    }

  }
}