using MangoDbCoreApi_5.Controllers;
using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MongoDB_CRUD_with_.NetCore_XUnit.Test
{
    public class BookCcontrollerTest
    {

        private readonly Mock<IBooksServices> mockBookserive;

        //private readonly Mock<IJsonSchemaValidator> mockBookserive;


        private readonly BooksController bookController;

        private List<Book> book;

        public BookCcontrollerTest()
        {
            mockBookserive = new Mock<IBooksServices>();
            bookController = new BooksController(mockBookserive.Object);
            createBookStore();
        }

        [Fact]
        public async void Get_ActionExecute_ReturnOkResultWithBookList()
        {
            mockBookserive.Setup(x => x.GetAllBookAsync()).ReturnsAsync(book);
            var bookDetails = await bookController.GetAllBooks();         
            mockBookserive.Verify(x => x.GetAllBookAsync(), Times.Once);
            var resultType = Assert.IsType<OkObjectResult>(bookDetails);
            var resultModel = Assert.IsAssignableFrom<List<Book>>(resultType.Value);

        }

        public  List<Book> createBookStore()
        {
            book = new List<Book>()
            {
                new Book
                {
                     Id = "1",
                     author = new Author
                     {
                         FirstName ="om",
                         LastName ="sah",
                         Age =31,
                         Location="chennai"
                     },

                     bookName="My stroy",
                     category="stroy",
                     BookPrice =222

                },

                 new Book
                {
                     Id = "2",
                     author = new Author
                     {
                         FirstName ="om1",
                         LastName ="sah1",
                         Age =32,
                         Location="chennai1"
                     },
                     bookName="My stroy1",
                     category="stroy1",
                     BookPrice =2221

                },
                  new Book
                {
                      Id = "3",
                      author = new Author
                     {
                         FirstName ="om2",
                         LastName ="sah2",
                         Age =30,
                         Location="chennai2"
                     },
                     bookName="My stroy2",
                     category="stroy2",
                     BookPrice =2222
                     }
            };
            return book;
        }
    }
}
