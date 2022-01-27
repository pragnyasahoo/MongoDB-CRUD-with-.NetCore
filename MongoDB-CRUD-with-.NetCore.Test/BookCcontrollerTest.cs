using MangoDbCoreApi_5._0.Controllers;
using MangoDbCoreApi_5._0.Models;
using MangoDbCoreApi_5._0.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUD_with_.NetCore.Test
{
    [TestFixture]
    public class BookCcontrollerTest
    {

        private   Mock<IBookServices> mockBookserive;

        private   BookController bookController;

        private List<Book> book;


        [SetUp]
        public void Setup()
        {
            mockBookserive = new Mock<IBookServices>();
            bookController = new BookController(mockBookserive.Object);
            createBookStore();


        }

        [Test]
        public void Get_ActionExecute_ReturnOkResultWithProductList()
        {

            mockBookserive.Setup(X => X.GetAllBookAsync()).ReturnsAsync(book);
            var bookDetails = bookController.GetAllBooks();
            mockBookserive.Verify(x => x.GetAllBookAsync(), Times.Once());
            var okResult = (ObjectResult)((bookDetails).Result);
            var BookCount = ((ObjectResult)((bookDetails).Result)).Value ;
            Assert.AreEqual(((List<Book>)BookCount).Count, book.Count);
        }

        private List<Book> createBookStore()
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