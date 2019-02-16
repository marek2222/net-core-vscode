using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc_filmy.Models;

namespace mvc_filmy.Controllers
{
  public class FilmyController : Controller
  {
    private readonly FilmyKontekst _context;

    public FilmyController(FilmyKontekst context)
    {
      _context = context;
    }

    // GET: Filmy
    public async Task<IActionResult> Index(string gatunekFilmu, string szukane)
    {
      IQueryable<string> gatunkiQuery = from s in _context.Film 
        orderby s.Gatunek 
        select s.Gatunek;
      var filmy = from f in _context.Film 
        select f;
      if (!String.IsNullOrEmpty(szukane))
      {
          filmy = filmy.Where(w => w.Tytul.Contains(szukane));
      }
      if (!String.IsNullOrEmpty(gatunekFilmu))
      {
          filmy = filmy.Where(w => w.Gatunek == gatunekFilmu);
      }
      var gatunekFilmuVM = new GatunekFilmuViewModel{
        Gatunki = new SelectList(await gatunkiQuery.Distinct().ToListAsync()),
        Filmy = await filmy.ToListAsync()
      };
      return View(gatunekFilmuVM);
    }

    // GET: Filmy/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var film = await _context.Film
          .FirstOrDefaultAsync(m => m.Id == id);
      if (film == null)
      {
        return NotFound();
      }

      return View(film);
    }

    // GET: Filmy/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Filmy/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Tytul,DataWydania,Gatunek,Cena,Ocena")] Film film)
    {
      if (ModelState.IsValid)
      {
        _context.Add(film);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(film);
    }

    // GET: Filmy/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var film = await _context.Film.FindAsync(id);
      if (film == null)
      {
        return NotFound();
      }
      return View(film);
    }

    // POST: Filmy/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,DataWydania,Gatunek,Cena,Ocena")] Film film)
    {
      if (id != film.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(film);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!FilmExists(film.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(film);
    }

    // GET: Filmy/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var film = await _context.Film
          .FirstOrDefaultAsync(m => m.Id == id);
      if (film == null)
      {
        return NotFound();
      }

      return View(film);
    }

    // POST: Filmy/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var film = await _context.Film.FindAsync(id);
      _context.Film.Remove(film);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool FilmExists(int id)
    {
      return _context.Film.Any(e => e.Id == id);
    }
  }
}
