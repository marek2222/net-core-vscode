using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using booklist_razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace booklist_razor.Pages.BookList {
	public class EditModel : PageModel {
		private BooksContext _db;
		[TempData]
		public string Message { get; set; }

		public EditModel (BooksContext db) {
			_db = db;
		}

		public IEnumerable<Book> Books { get; set; }

		public async Task OnGet () {
			Books = await _db.Books.ToListAsync ();
		}
		public async Task<IActionResult> OnPostDelete (int id) {
			var book = _db.Books.Find (id);
			_db.Books.Remove (book);
			await _db.SaveChangesAsync ();

			Message = "Book Deleted Successfully!";

			return RedirectToPage ();
		}
	}
}