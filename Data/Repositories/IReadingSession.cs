using Library.Models;

namespace Library.Data.Repository {
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksASync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
