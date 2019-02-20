using Microsoft.AspNetCore.Mvc;
using real_apps.Models;

namespace real_apps.Controllers
{
  [Route("product")]
  public class ProductController : Controller
  {
    [Route("")]
    [Route("index")]
    [Route("~/")]
    public IActionResult Index()
    {
      ProductModel productModel = new ProductModel();
      ViewBag.products = productModel.findAll();
      return View();
    }
  }
}