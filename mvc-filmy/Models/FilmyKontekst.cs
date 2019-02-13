using Microsoft.EntityFrameworkCore;

namespace mvc_filmy.Models
{
  public class FilmyKontekst : DbContext
  {
    public FilmyKontekst(DbContextOptions<FilmyKontekst> opcje) : base(opcje)
    {
    }

    public DbSet<Film> Filmy { get; set; }
  }
}