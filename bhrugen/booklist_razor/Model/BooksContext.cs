using Microsoft.EntityFrameworkCore;

namespace booklist_razor.Model {
	public class BooksContext : DbContext {
		public BooksContext (DbContextOptions<BooksContext> options) 
			: base (options) { }
		public DbSet<Book> Books { get; set; }
	}
}