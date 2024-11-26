using LibraryAPI.Models;

namespace LibraryAPI.Services
{
	public interface IBookService
	{
		public ICollection<Book> GetAllBooks();
		public ICollection<Book> GetBooksByGenre(Ganre ganre);
		public ICollection<Book> GetMostReadBooks(int limit);
		public ICollection<Book> GetBooksWithHighRating();
		public ICollection<Book> SearchBookByName(string name);

		public Book GetBook(int id);
		public Book CreateNewBook(Book book);
	}
}
