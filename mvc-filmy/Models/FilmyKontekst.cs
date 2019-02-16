using Microsoft.EntityFrameworkCore;

namespace mvc_filmy.Models
{
  public class FilmyKontekst : DbContext
  {
    public FilmyKontekst(DbContextOptions<FilmyKontekst> opcje) : base(opcje)
    {
    }

    public DbSet<Film> Film { get; set; }
    public DbSet<Movie> Movie { get; set; }
  }
}