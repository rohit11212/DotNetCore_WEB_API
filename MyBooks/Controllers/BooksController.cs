using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.NewFolder;
using MyBooks.Data.Services;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        public BookService BookService;

        public BooksController(BookService bookService)
        {
            this.BookService = bookService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        { 
            BookService.AddBook(book);
            return Ok();
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        { 
            var books = BookService.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("get-book-id/{id}")]
        public IActionResult GetBookById(int id)
        { 
            var book = BookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("Update-Book/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var books = BookService.UpdateBookId(id, book);
            return Ok(books);
        }
        [HttpDelete("Delete-Book/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            BookService.DeleteBookId(id);
            return Ok();
        }

    }
}
