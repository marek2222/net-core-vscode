using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace mvc_filmy.Models
{
    public static class DaneStartowe
    {
        public static void Utworz(IServiceProvider serviceProvider)
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
                        Cena = 7.99M
                    },

                    new Film
                    {
                        Tytul = "Pogromcy duchów ",
                        DataWydania = DateTime.Parse("1984-3-13"),
                        Gatunek = "Komedia",
                        Cena = 8.99M
                    },

                    new Film
                    {
                        Tytul = "Pogromcy duchów 2",
                        DataWydania = DateTime.Parse("1986-2-23"),
                        Gatunek = "Komedia",
                        Cena = 9.99M
                    },

                    new Film
                    {
                        Tytul = "Rio Bravo",
                        DataWydania = DateTime.Parse("1959-4-15"),
                        Gatunek = "Western",
                        Cena = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}