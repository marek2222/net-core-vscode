using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using real_apps.Models;

namespace real_apps.Controllers {

  [Route ("demo")]
  public class DemoController : Controller {
    [Route ("")]
    [Route ("index")]
    [Route ("~/")]
    public IActionResult Index () {
      return View ();
    }

    [Route ("demo1")]
    public IActionResult Demo1 () {
      return new JsonResult ("Hello");
    }

    [Route ("demo2/{fullName}")]
    public IActionResult Demo2 (string fullName) {
      return new JsonResult ("Hello " + fullName);
    }

    [Route ("demo3")]
    public IActionResult Demo3 () {
      var product = new Product () {
        Id = "p01",
        Name = "name 1",
        Price = 123
      };
      return new JsonResult (product);
    }

    [Route ("demo4")]
    public IActionResult Demo4 () {
      var products = new List<Product> () {
        new Product () {
          Id = "p01",
          Name = "name 1",
          Price = 123
        },
        new Product () {
          Id = "p02",
          Name = "name 2",
          Price = 456
        },
        new Product () {
          Id = "p03",
          Name = "name 3",
          Price = 789
        }
      };
      return new JsonResult (products);
    }

  }
}