using Microsoft.EntityFrameworkCore;

namespace booklist.Models {
  
  public class BooksContext : DbContext {
    public BooksContext (DbContextOptions<BooksContext> options) 
      : base (options) { }

    public DbSet<Book> Books { get; set; }
  }

}