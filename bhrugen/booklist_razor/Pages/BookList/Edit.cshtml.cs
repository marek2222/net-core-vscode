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

		public EditModel (BooksContext db) {
			_db = db;
		}

		[BindProperty]
		public Book Book { get; set; }

		[TempData]
		public string Message { get; set; }

		public void OnGet (int id) {
			Book =  _db.Books.Find(id);
		}

		public async Task<IActionResult> OnPost(){
				if (ModelState.IsValid)
				{
					var bookInDb = _db.Books.Find(Book.Id);
					bookInDb.ISBN 	= Book.ISBN;
					bookInDb.Tytul 	= Book.Tytul;
					bookInDb.Autor 	= Book.Autor;
					bookInDb.Cena 	= Book.Cena;
					bookInDb.Dostepnosc = Book.Dostepnosc;

					await _db.SaveChangesAsync();
					Message = "Book update succesfully";

					return RedirectToPage("Index");
				}
				return RedirectToPage();
		} 

	}
}