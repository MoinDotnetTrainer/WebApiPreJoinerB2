using APIDAL.Interfaces;
using APIDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiPreJoinerB2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksOpsController : ControllerBase
    {
        public readonly IBook _book;
        public BooksOpsController(IBook book)
        {
            _book = book;
        }

        [HttpGet]
        [Route("Bookslist")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _book.GetAllBooksAsync();
            return Ok(books);  // status code 200
        }

        [HttpGet("{id}", Name = "GetBookById")]

        public async Task<IActionResult> GetBookById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid book ID."); // 400
            var book = await _book.GetBookByIdAsync(id);
            if (book == null)
                return NotFound(); // 404
            return Ok(book); // 200
        }
        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> AddBook(Books book)
        {
            try
            {
                var addedBook = await _book.AddBookAsync(book); // server down
                return CreatedAtAction(nameof(GetBookById), new { id = addedBook.Id }, addedBook); // 201

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBook(int id, Books book)
        {
            var updatedBook = await _book.UpdateBookAsync(id, book);
            if (updatedBook == null)
                return NotFound();
            return Ok(updatedBook);
        }
        [HttpDelete("{id}", Name = "DeleteBook")]

        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _book.DeleteBookAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
