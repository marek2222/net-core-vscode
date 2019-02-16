using System.IO;
using Microsoft.AspNetCore.Http;
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
      return View("Index", new Product());
    }

    [Route("save")]
    public IActionResult Save(Product product, IFormFile photo)
    {
      if (photo == null || photo.Length == 0)
      {
        return Content("File not selected");
      }
      else
      {
        var path = Path.Combine(Directory.GetCurrentDirectory(),
          "wwwroot/images", photo.FileName);
        var stream = new FileStream(path, FileMode.Create);
        photo.CopyToAsync(stream);
        product.Photo = photo.FileName;
      }
      ViewBag.product = product;
      return View("Success");
    }
  }
}