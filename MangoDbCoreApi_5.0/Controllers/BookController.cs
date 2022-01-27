using MangoDbCoreApi_5._0.Models;
using MangoDbCoreApi_5._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5._0.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _bookServices.GetAllBookAsync().ConfigureAwait(false));

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
            return Ok(await _bookServices.GetBookByIdAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"> Send the book type data</param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync(Book book)
        {
            var bookDetails = await _bookServices.CreateBookAsync(book);
            if (bookDetails == null)
            {
                return NotFound(book);
            }
            var result = new BookResponse { BookId = book.Id };
            return new JsonResult(result)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBookAsync(string id, Book book)
        {
            var bookDetails = _bookServices.GetBookByIdAsync(id);
            if (bookDetails == null)
            {
                return NotFound();
            }
            await _bookServices.UpdateBookAsync(id, book); ;
            return NoContent();
        }

        [HttpDelete] 
        [Route("{id}")]
        public async Task<IActionResult> DeleteBookAsync(string id)
        {
             await _bookServices.GetBookByIdAsync(id).ConfigureAwait(false);
            if (id == null)
            {
                return NotFound();
            }
            await _bookServices.DeleteBookAsync(id);
            return NoContent();
        }


    }
}
