using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using real_apps.Models;

namespace real_apps.Controllers 
{
  [Route("api/product")]
  public class ProductRestController : Controller
  {
    private RealAppContext db = new RealAppContext();

    [Produces("application/json")]
    [HttpGet("search")]
    // public async Task<IActionResult> Search()
    public IActionResult Search()
    {
      try
      {
        string term = HttpContext.Request.Query["term"].ToString();
        var names = db.Products.Where(p => p.Name.Contains(term)).Select(p => p.Name).ToList();
        return Ok(names);
      }
      catch
      {
        return BadRequest();
      }
    }
  }
}