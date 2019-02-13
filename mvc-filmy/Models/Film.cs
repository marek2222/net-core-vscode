using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_filmy.Models
{
  public class Film
  {
    public int Id { get; set; }
    public string Tytul { get; set; }


    [Display(Name = "Data wydania")]
    [DataType(DataType.Date)]
    public DateTime DataWydania { get; set; }
    public string Gatunek { get; set; }


    [Column(TypeName = "decimal(18, 2)")]
    public decimal Cena { get; set; }
  }
}

// dotnet aspnet-codegenerator controller -name FilmyController -m Film -dc FilmyKontekst --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries