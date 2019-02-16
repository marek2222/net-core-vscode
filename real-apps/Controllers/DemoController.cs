using Microsoft.AspNetCore.Mvc;
using real_apps.Helpers;
using real_apps.Models;

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
      return View("Index", new Product());
    }

    [Route("save")]
    [HttpPost]
    public IActionResult Save(int age, string username, Product product)
    {
      TempData["age"] = age;
      TempData["username"] = username;
      TempDataHelper.Put<Product>(TempData, "product", product);
      return RedirectToAction("showFlashAttributes", "demo");
    }

    [Route("showFlashAttributes")]
    public IActionResult showFlashAttributes()
    {
      return View("Result");
    }
  }
}