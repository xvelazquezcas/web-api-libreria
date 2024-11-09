using libreria_XGVC.Data.Services;
using libreria_XGVC.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreria_XGVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _bookService.GetAllBks();
            return Ok(allbooks);
        }

        [HttpGet("get-book-by-id/{id}")] 
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookId(id);
            return Ok(book);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookId(int id, [FromBody]BookVM book)
        {
            var updateBook = _bookService.UpdateBookByID(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("delete-book-by-id/{id}")] 
        public IActionResult DeleteBookById(int id)
        {
            _bookService.DeleteBookById(id);
            return Ok();
        }
        
    }
}
