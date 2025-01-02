using MyInBook.Core.MyEntities;

namespace MyInBook.Business.Abstract;

public interface IBookService
{
    Task CreateBook(Book model);
    Task UpdateBook(Book model);
    Task DeleteBook(Book model);
    Task<List<Book>> ListAllBook();
    Task<Book> GetBookById(int id);
}
