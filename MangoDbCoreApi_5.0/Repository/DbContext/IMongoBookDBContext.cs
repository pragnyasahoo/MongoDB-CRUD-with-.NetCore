using MongoDB.Driver;

namespace MangoDbCoreApi_5.Repository.Repository.DbContext
{
     public interface IMongoBookDBContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}