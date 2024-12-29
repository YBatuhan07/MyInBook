using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyInBook.Core.MyEntities;
using MyInBook.Data;

namespace MyInBook.Web.Controllers;

public class BookController : Controller
{
    private readonly MyInBookDatabaseContext _context;

    public BookController(MyInBookDatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var books = await _context.Books.ToListAsync();
        return View(books);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        if (ModelState.IsValid)
        {
            book.Created = DateTime.Now;
            book.Updated = DateTime.Now;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(book);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Book book)
    {
        if (id != book.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            book.Updated = DateTime.Now;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(book);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}
