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

        [HttpGet("GetAllBooks")]

        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _book.GetAllBooksAsync();
            return Ok(books);  // status code 200
        }

        [HttpGet("GetBookById/{Id}")]


        public async Task<IActionResult> GetBookById([FromQuery]int id)
        {
            if (id <= 0)
                return BadRequest("Invalid book ID."); // 400
            var book = await _book.GetBookByIdAsync(id);
            if (book == null)
                return NotFound(); // 404
            return Ok(book); // 200
        }


        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBook([FromBody] Books book)
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


        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id, [FromBody]Books book)
        {
            var updatedBook = await _book.UpdateBookAsync(id, book);
            if (updatedBook == null)
                return NotFound();
            return Ok(updatedBook);
        }


        [HttpDelete("DeleteBook/{Id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _book.DeleteBookAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
