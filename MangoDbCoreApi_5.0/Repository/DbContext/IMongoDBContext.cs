using MongoDB.Driver;

namespace MangoDbCoreApi_5.Repository.Repository.DbContext
{
     public interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}