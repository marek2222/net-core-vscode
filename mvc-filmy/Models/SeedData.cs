using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace mvc_filmy.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new FilmyKontekst(
          serviceProvider.GetRequiredService<
              DbContextOptions<FilmyKontekst>>()))
      {

        // Look for any movies.
        if (context.Film.Any())
        {
          return;   // DB has been seeded
        }

        context.Film.AddRange(
            new Film
            {
              Tytul = "Kiedy Harry spotkał Sally",
              DataWydania = DateTime.Parse("1989-2-12"),
              Gatunek = "Romantyczna Komedia",
              Cena = 7.99M,
              Ocena="R"
            },

            new Film
            {
              Tytul = "Pogromcy duchów ",
              DataWydania = DateTime.Parse("1984-3-13"),
              Gatunek = "Komedia",
              Cena = 8.99M,
              Ocena="G"
            },

            new Film
            {
              Tytul = "Pogromcy duchów 2",
              DataWydania = DateTime.Parse("1986-2-23"),
              Gatunek = "Komedia",
              Cena = 9.99M,
              Ocena="G"
            },

            new Film
            {
              Tytul = "Rio Bravo",
              DataWydania = DateTime.Parse("1959-4-15"),
              Gatunek = "Western",
              Cena = 3.99M,
              Ocena="NA"
            }
        );
        context.SaveChanges();



        // Look for any movies.
        if (context.Movie.Any())
        {
          return;   // DB has been seeded
        }

        context.Movie.AddRange(
            new Movie
            {
              Title = "When Harry Met Sally",
              ReleaseDate = DateTime.Parse("1989-2-12"),
              Genre = "Romantic Comedy",
              Price = 7.99M,
              Rating="R"
            },

            new Movie
            {
              Title = "Ghostbusters ",
              ReleaseDate = DateTime.Parse("1984-3-13"),
              Genre = "Comedy",
              Price = 8.99M,
              Rating="G"
            },

            new Movie
            {
              Title = "Ghostbusters 2",
              ReleaseDate = DateTime.Parse("1986-2-23"),
              Genre = "Comedy",
              Price = 9.99M,
              Rating="G"
            },

            new Movie
            {
              Title = "Rio Bravo",
              ReleaseDate = DateTime.Parse("1959-4-15"),
              Genre = "Western",
              Price = 3.99M,
              Rating="NA"
            }
        );
        context.SaveChanges();
      }
    }
  }
}