using MongoDB.Driver;

namespace MangoDbCoreApi_5.Repository.Repository.BookDbContext
{
     public interface IMongoBookDBContext
    {
        IMongoCollection<Book> GetCollection<Book>();
    }
}