using Microsoft.EntityFrameworkCore;

namespace real_apps.Models
{
  public class RealAppContext : DbContext
  {
    public RealAppContext(DbContextOptions<RealAppContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
  }
}
