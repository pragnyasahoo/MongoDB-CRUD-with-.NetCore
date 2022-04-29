using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Repository.DbRepository;
using MangoDbCoreApi_5.Repository.Repository.BookDbContext;

namespace MangoDbCoreApi_5.Repository.BookDbContext
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
         public BooksRepository(IMongoBookDBContext context) : base(context)
        {
        }
    }
}