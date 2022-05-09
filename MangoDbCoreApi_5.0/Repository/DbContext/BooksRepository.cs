using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Repository.DbContext;
using MangoDbCoreApi_5.Repository.DbRepository;
using MangoDbCoreApi_5.Repository.Repository.DbContext;

namespace MangoDbCoreApi_5.Repository.BookDbContext
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
         public BooksRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}