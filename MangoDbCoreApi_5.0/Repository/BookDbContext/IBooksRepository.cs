using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Repository.DbRepository;

namespace MangoDbCoreApi_5.Repository.BookDbContext
{
    public interface IBooksRepository: IBaseRepository<Book>
    {
    }
}
