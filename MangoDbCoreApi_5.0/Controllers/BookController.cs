using MangoDbCoreApi_5.Configuration;
using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Services;
using MangoDbCoreApi_5.Utility.Implement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookServices _bookServices;
        private readonly IJsonSchemaValidator _jsonSchema;

        // public BookController(IBookServices bookServices, IJsonSchemaValidator jsonSchema)
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices; 

        }

        [HttpGet]
        [TypeFilter(typeof(LogFilter), Arguments = new object[] { "Abc", "Xyz" })]
        public async Task<IActionResult> GetAllBooks()
        {
           var result= await _bookServices.GetAllBookAsync().ConfigureAwait(false);
           if(result == null)
            {
                return NotFound();
            }
           return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [TypeFilter(typeof(LogFilter), Arguments = new object[] { "Abc", "Xyz" })]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
           var result = await _bookServices.GetBookByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"> Send the book type data</param>
        /// <returns></returns>

        [HttpPost]
        [TypeFilter(typeof(LogFilter), Arguments = new object[] { "Abc", "Xyz" })]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBookAsync(Book book)
        {

            if (string.IsNullOrEmpty(book.ToString()))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            //var s= await _jsonSchema.ValidateJsonSchemaAsync(JsonConvert.SerializeObject(book));
            var bookDetails = await _bookServices.CreateBookAsync(book);
            if (bookDetails == null)
            {
                return NotFound(book);
            }
            /*var result = new BookResponse { BookId = book.Id };
            return new JsonResult(result)
            {
                StatusCode = StatusCodes.Status201Created
            };*/
            return Created("", bookDetails);
        }

        [HttpPut]
        [Route("{id}")]
        [TypeFilter(typeof(LogFilter), Arguments = new object[] { "Abc", "Xyz" })]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> UpdateBookAsync(string id, Book book)
        {
            var bookDetails = await _bookServices.GetBookByIdAsync(id);
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
