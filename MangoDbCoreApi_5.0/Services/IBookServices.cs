using MangoDbCoreApi_5._0.Models;
using MangoDbCoreApi_5._0.Models.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5._0.Services
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
