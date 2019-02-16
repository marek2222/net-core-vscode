using Microsoft.AspNetCore.Mvc;
using real_apps.Models;

namespace real_apps.Controllers
{
  [Route("account")]  
  public class AccountController  : Controller
  {
    [Route("")]
    [Route("index")]
    [Route("~/")]
    public IActionResult Index()
    {
      return View("Index", new Account());
    }

    [HttpPost]
    public IActionResult Save(Account account)
    {
      if (ModelState.IsValid)
      {
        ViewBag.account = account;
        return View("Success");
      }
      else 
      {
        return View("Index");
      }
    }
  }
}