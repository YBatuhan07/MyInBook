using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyInBook.Business.Abstract;
using MyInBook.Core.MyEntities;
using MyInBook.Data;

namespace MyInBook.Web.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> ListBooks()
    {
        var result = await _bookService.ListAllBook();
        return View(result);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
       await _bookService.CreateBook(book);
       
        return RedirectToAction("ListBooks");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _bookService.GetBookById(id);
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

            await _bookService.UpdateBook(book);
            return RedirectToAction("ListBooks");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _bookService.GetBookById(id);
       
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Book model)
    {
        await _bookService.DeleteBook(model);
        return RedirectToAction("ListBooks");
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var result = await _bookService.GetBookById(id);
        return View(result);
    }
}
