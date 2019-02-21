using Microsoft.AspNetCore.Mvc;

namespace real_apps.Controllers {
  [Route ("aboutus")]
  public class AboutUsController : Controller {
    [Route("")]
    [Route("index")]
    [Route("~/")]
    public IActionResult Index () {
      return View ();
    }
  }
}