using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_filmy.Models
{
  public class Film
  {
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Tytul { get; set; }

    [Display(Name = "Data wydania")]
    [DataType(DataType.Date)]
    public DateTime DataWydania { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Cena { get; set; }

    [Required]
    [StringLength(30)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string Gatunek { get; set; }

    [Required]
    [StringLength(5)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    public string Ocena { get; set; }
  }
}

// dotnet aspnet-codegenerator controller -name FilmyController -m Film -dc FilmyKontekst --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries