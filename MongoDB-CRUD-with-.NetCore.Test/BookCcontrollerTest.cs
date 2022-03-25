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

        private Mock<IBookServices> mockBookserive;

        private BookController bookController;

        private List<Book> book; 

        [SetUp]
        public void Setup()
        {
            mockBookserive = new Mock<IBookServices>();
            bookController = new BookController(mockBookserive.Object);
           book = createBookStore();
        }

        [Test]
        public void Get_ActionExecute_ReturnOkResultWithProductList()
        {

            mockBookserive.Setup(X => X.GetAllBookAsync()).ReturnsAsync(book);
            var bookDetails = bookController.GetAllBooks();
            mockBookserive.Verify(x => x.GetAllBookAsync(), Times.Once());
            var okResult = (ObjectResult)((bookDetails).Result);
            var BookCount = ((ObjectResult)((bookDetails).Result)).Value;
            Assert.AreEqual(((List<Book>)BookCount).Count, book.Count);
        }

        [Test]
        [TestCase("3ef9e33e1c4d3f78c4e72c1f")]
        public void test_GetBookById(string id)
        {
            //Book book = null;
            var bookDetails = book.Find(x => x.Id.Equals(id));
            mockBookserive.Setup(x => x.GetBookByIdAsync(id)).ReturnsAsync(bookDetails);
            var result = bookController.GetBookById(id);
            mockBookserive.Verify(x => x.GetBookByIdAsync(id), Times.Once());
            var okResult = (ObjectResult)((result).Result);
            var BookCount = ((ObjectResult)(result.Result)).Value;
            
        }

        private  List<Book> createBookStore()
        {
            book = new List<Book>()
            {
                new Book
                {
                     Id = "3ef9e33e1c4d3f78c4e72c1f",
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
                     Id = "5ef9e45e1c4d3f78c4e72c1f",
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
                      Id = "4ef9e33e3c4d5f78c4e72c1f",
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