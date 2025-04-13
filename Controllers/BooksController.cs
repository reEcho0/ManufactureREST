using BookRESTapi.Models;
using BookRESTapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookRESTapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return _bookService.GetAll();
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBook = _bookService.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = createdBook.Id }, createdBook);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Book ID mismatch");
            }

            if (!_bookService.Update(id, book))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (!_bookService.Delete(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
