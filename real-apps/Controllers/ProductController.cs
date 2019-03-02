using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using real_apps.Models;

namespace real_apps.Controllers 
{
  public class ProductController : Controller 
  {
    public IActionResult Index()
    {
        return View();
    }

  }
}