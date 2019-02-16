using System;
using Microsoft.AspNetCore.Mvc;

namespace real_apps.Controllers
{
   public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.age = 20;
            ViewBag.fullName = "Kevin";
            ViewBag.status = true;
            ViewBag.price = 4.5;
            ViewBag.birthday = DateTime.Now;
            return View();
        }
    }
}