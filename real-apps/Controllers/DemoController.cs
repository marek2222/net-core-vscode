
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using real_apps.Models;

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