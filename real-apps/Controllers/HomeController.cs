using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using real_apps.Models;

namespace real_apps.Controllers {
  [Route("Home")]
  public class HomeController : Controller {
    [Route ("")]
    [Route ("Index")]
    [Route ("~/")]
    public IActionResult Index () {
      return View ();
    }

    public IActionResult Privacy () {
      return View ();
    }

    [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error () {
      return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}