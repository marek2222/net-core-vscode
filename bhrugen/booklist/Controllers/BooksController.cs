using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using booklist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace booklist.Controllers {

  public class BooksController : Controller {
  
    private readonly BooksContext _db;

    public BooksController (BooksContext db) {
      _db = db;
    }

    // GET: Books
    public async Task<IActionResult> Index () {
      return View (await _db.Books.ToListAsync ());
    }

    // GET: Books/Details/5
    public async Task<IActionResult> Details (int? id) {
      if (id == null) {
        return NotFound ();
      }

      var book = await _db.Books
        .FirstOrDefaultAsync (m => m.Id == id);
      if (book == null) {
        return NotFound ();
      }

      return View (book);
    }

    // GET: Books/Create
    public IActionResult Create () {
      return View ();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create ([Bind ("Id,Name")] Book book) {
      if (ModelState.IsValid) {
        _db.Add (book);
        await _db.SaveChangesAsync ();
        return RedirectToAction (nameof (Index));
      }
      return View (book);
    }


    // GET: Books/Edit/5
    public async Task<IActionResult> Edit (int? id) {
      if (id == null) {
        return NotFound ();
      }

      var book = await _db.Books.FindAsync (id);
      if (book == null) {
        return NotFound ();
      }
      return View (book);
    }

    // POST: Books/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit (int id, [Bind ("Id,Name")] Book book) {
      if (id != book.Id) {
        return NotFound ();
      }

      if (ModelState.IsValid) {
        try {
          _db.Update (book);
          await _db.SaveChangesAsync ();
        } catch (DbUpdateConcurrencyException) {
          if (!BookExists (book.Id)) {
            return NotFound ();
          } else {
            throw;
          }
        }
        return RedirectToAction (nameof (Index));
      }
      return View (book);
    }

    // GET: Books/Delete/5
    public async Task<IActionResult> Delete (int? id) {
      if (id == null) {
        return NotFound ();
      }

      var book = await _db.Books
        .FirstOrDefaultAsync (m => m.Id == id);
      if (book == null) {
        return NotFound ();
      }

      return View (book);
    }

    // POST: Books/Delete/5
    [HttpPost, ActionName ("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed (int id) {
      var book = await _db.Books.FindAsync (id);
      _db.Books.Remove (book);
      await _db.SaveChangesAsync ();
      return RedirectToAction (nameof (Index));
    }

    private bool BookExists (int id) {
      return _db.Books.Any (e => e.Id == id);
    }
  }
}