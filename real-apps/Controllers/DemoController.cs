using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace real_apps.Controllers
{
  public class DemoController : Controller
  {
    public IActionResult Index()
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");
      var configuration = builder.Build();
      ViewBag.result1 = configuration["Message"];
      ViewBag.result2 = configuration["MyConfigs:Config1"];
      ViewBag.result3 = configuration["MyConfigs:Config2"];
      ViewBag.result4 = configuration["MyConfigs:Config3"];
      ViewBag.result5 = configuration["Logging:LogLevel:Default"];
      return View();
    }
  }
}