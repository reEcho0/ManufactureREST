using BookRESTapi.Models;

namespace BookRESTapi.Services
{
    public class BookService
    {
        private readonly List<Book> _books;
        private int _nextId = 1;

        public BookService()
        {
            _books = new List<Book>();
        }

        public List<Book> GetAll() => _books;

        public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public Book Create(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public bool Update(int id, Book book)
        {
            var existingBook = GetById(id);
            if (existingBook == null)
                return false;

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Year = book.Year;
            return true;
        }

        public bool Delete(int id)
        {
            var book = GetById(id);
            if (book == null)
                return false;

            _books.Remove(book);
            return true;
        }
    }
}
