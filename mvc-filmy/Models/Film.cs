using System;
using System.ComponentModel.DataAnnotations;

namespace mvc_filmy.Models
{
  public class Film
  {
    public int Id { get; set; }
    public string Tytul { get; set; }

    [DataType(DataType.Date)]
    public DateTime DataWydania { get; set; }
    public string Gatunek { get; set; }
    public decimal Cena { get; set; }
  }
}

// dotnet aspnet-codegenerator controller -name FilmyController -m Film -dc MvcFilmyKontekst --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries