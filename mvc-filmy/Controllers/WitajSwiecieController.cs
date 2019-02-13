using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace mvc_filmy.Controllers
{
  public class WitajSwiecieController : Controller
  {
    // 
    // GET: /WitajSwiecie/
    public string Index()
    {
      return "To jest domyślna akcja...";
    }

    // 
    // GET: /WitajSwiecie/Witaj?nazwa=marek2222&liczba=3 
    public string Witaj(string nazwa, int liczba = 1)
    {
      return HtmlEncoder.Default.Encode($"Cześć {nazwa}, liczba to: {liczba}");
    }
  }
}