using MangoDbCoreApi_5._0.Controllers;
using MangoDbCoreApi_5._0.Models;
using MangoDbCoreApi_5._0.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MongoDB_CRUD_with_.NetCore_XUnit.Test
{
    public class BookCcontrollerTest
    {

        private readonly Mock<IBookServices> mockBookserive;

        private readonly BookController bookController;

        private List<Book> book;

        public BookCcontrollerTest()
        {
            mockBookserive = new Mock<IBookServices>();
            bookController = new BookController(mockBookserive.Object);
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
                     author = "shree",
                     bookName="My stroy",
                     category="stroy",
                     BookPrice =222

                },

                 new Book
                {
                     author = "shree1",
                     bookName="My stroy1",
                     category="stroy1",
                     BookPrice =2221

                },
                  new Book
                {
                     author = "shree2",
                     bookName="My stroy2",
                     category="stroy2",
                     BookPrice =2222

                },
            };
            return book;
        }
    }
}
