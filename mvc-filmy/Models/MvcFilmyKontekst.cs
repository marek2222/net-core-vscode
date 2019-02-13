using Microsoft.EntityFrameworkCore;

namespace mvc_filmy.Models
{
  public class MvcFilmyKontekst : DbContext
  {
    public MvcFilmyKontekst(DbContextOptions<MvcFilmyKontekst> opcje) : base(opcje)
    {
    }

    public DbSet<Film> Film { get; set; }
  }
}