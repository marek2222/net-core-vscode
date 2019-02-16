using Microsoft.AspNetCore.Mvc;
using real_apps.Models;

namespace real_apps.Controllers
{
  public class DemoController : Controller
  {
    public IActionResult Index()
    {
      Product product = new Product()
      {
        Id = "p01",
        Name = "Name 1",
        Photo = "Thumb1.jpg",
        Price = 5.5,
        Quantity = 4
      };
      ViewBag.product = product;
      return View();
    }
  }
}