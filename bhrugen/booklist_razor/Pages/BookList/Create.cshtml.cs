using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using booklist_razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace booklist_razor.Pages.BookList {
    
    public class CreateModel : PageModel {
        private BooksContext _db;

        [TempData]
        public string Message { get; set; }

        public CreateModel (BooksContext db) {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet () { }

        public async Task<IActionResult> OnPost () {
            if (!ModelState.IsValid) {
                return Page ();
            }
            _db.Books.Add (Book);
            await _db.SaveChangesAsync ();
            Message = "New Book Added successfully!";
            return RedirectToPage ("Index");
        }
    }
}