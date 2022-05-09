using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Models.Abstract;
using MangoDbCoreApi_5.Models.ContentDbModel;
using MangoDbCoreApi_5.Repository.Repository.DbContext;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;

namespace MangoDbCoreApi_5.Repository.DbContext
{
    public class MongoDBContext : IMongoBookDBContext
    {
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        private IMongoDatabase _db { get; set; }

        public MongoDBContext(IOptions<MangoDbSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DataBaseName); 
        }
        public IMongoCollection<T> GetCollection<T>()
        {
            //return _db.GetCollection<T>(name); / If the model class and the Collection  name is same Then retrieve the collection
            string collectionName = (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()
        as BsonCollectionAttribute).CollectionName;
            return _db.GetCollection<T>(collectionName); // If the model class and the Collection name is different Then retrieve the collection
        }
    }
}
