using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using real_apps.Models;

namespace real_apps.Controllers
{
  public class DemoController : Controller
  {
    public IActionResult Index()
    {
      List<Product> products = new List<Product>() {
        new Product()
        {
          Id = "p01",
          Name = "Name 1",
          Photo = "Thumb1.jpg",
          Price = 5.5,
          Quantity = 4
        },
        new Product()
        {
          Id = "p02",
          Name = "Name 2",
          Photo = "Thumb2.jpg",
          Price = 7,
          Quantity = 3
        },
        new Product()
        {
          Id = "p03",
          Name = "Name 3",
          Photo = "Thumb3.jpg",
          Price = 8,
          Quantity = 6
        }
      };
      ViewBag.products = products;
      return View();
    }
  }
}