using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace mvc_filmy.Controllers
{
  public class WitajSwiecieController : Controller
  {
    // 
    // GET: /WitajSwiecie/
    public IActionResult Index()
    {
      return View();
    }
    
    // 
    // GET: /WitajSwiecie/Witaj?nazwa=marek2222&liczba=3 
    public IActionResult Witaj(string nazwa, int liczba = 1)
    {
      ViewData["Wiadomosc"] = "Cześć " + nazwa;
      ViewData["Liczba"] = liczba;
      return View();
    }
  }
}