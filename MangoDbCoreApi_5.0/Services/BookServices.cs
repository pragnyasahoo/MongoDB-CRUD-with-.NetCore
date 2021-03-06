using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Models.Abstract;
using MangoDbCoreApi_5.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5.Services.RepositoryService
{
    public class BookServices:IBookServices
    { 
        private readonly IBookRepository bookRepository;
        public BookServices(IBookRepository bookRepositary)
        { 
            this.bookRepository = bookRepositary;
        }

        public Task<Book> CreateBookAsync(Book book)
        {
           return bookRepository.CreateAsync(book);            
        }

        public Task DeleteBookAsync(string id)
        {
           return bookRepository.DeleteAsync(id);
        }

        public Task<List<Book>> GetAllBookAsync()
        {
            return bookRepository.GetAllBookAsync();
        }

        public Task<Book> GetBookByIdAsync(string id)
        {
            return bookRepository.GetByIdAsync(id);
        }

        public Task UpdateBookAsync(string id, Book book)
        {
            return bookRepository.UpdateAsync(id,book);
        }
    }
}
