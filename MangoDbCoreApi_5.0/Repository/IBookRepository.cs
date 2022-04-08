using MangoDbCoreApi_5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBookAsync();
        Task<Book> GetByIdAsync(string id);
        Task<Book> CreateAsync(Book book);
        Task UpdateAsync(string Id,Book book); 
        Task DeleteAsync(string id);

    }
}
