using MyInBook.Business.Abstract;
using MyInBook.Core.MyEntities;
using MyInBook.Data;
using MyInBook.Data.Repositories.BookRepositories;
using System.Net;

namespace MyInBook.Business.Concrete;

public  class BookService : IBookService
{
    public readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task CreateBook(Book model)
    {
        await _bookRepository.CreateAsync(model);
    }

    public async Task DeleteBook(Book model)
    {
        await _bookRepository.DeleteAsync(model);
    }

    public async Task<Book> GetBookById(int id)
    {
        return await _bookRepository.GetAsync(id);
    }

    public async Task<List<Book>> ListAllBook()
    {
        return await _bookRepository.GetAllAsync();
    }

    public async Task UpdateBook(Book model)
    {
        await _bookRepository.UpdateAsync(model);
    }
}
