using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Models.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5.Services
{
    public interface IBookServices
    {
        Task<List<Book>> GetAllBookAsync();

        Task<Book> GetBookByIdAsync(string id);

        Task<Book> CreateBookAsync( Book book);

        Task DeleteBookAsync(string id);

        Task UpdateBookAsync(string id, Book book);
    }
}
