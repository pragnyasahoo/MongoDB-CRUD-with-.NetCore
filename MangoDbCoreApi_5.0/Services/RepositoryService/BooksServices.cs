using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Models.Abstract;
using MangoDbCoreApi_5.Repository;
using MangoDbCoreApi_5.Repository.DbContext;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5.Services
{
    public class BooksServices: IBooksServices
    { 
        private readonly IBooksRepository _bookRepository;
        public BooksServices(IBooksRepository bookRepositary)
        { 
            this._bookRepository = bookRepositary;
        }

        public Task<Book> CreateBookAsync(Book book)
        {
           return _bookRepository.CreateAsync(book);            
        }

        public Task DeleteBookAsync(string id)
        {
           return _bookRepository.DeleteAsync(id);
        }

        public Task<List<Book>> GetAllBookAsync()
        {
            return _bookRepository.GetAllBookAsync();
        }

        public Task<Book> GetBookByIdAsync(string id)
        {
            return _bookRepository.GetByIdAsync(id);
        }

        public Task UpdateBookAsync(string id, Book book)
        {
            return _bookRepository.UpdateAsync(id,book);
        }
    }
}
