using MangoDbCoreApi_5.Models;
using MangoDbCoreApi_5.Models.Abstract;
using MangoDbCoreApi_5.Repository.Repository.BookDbContext;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MangoDbCoreApi_5.Repository.BookDbContext
{
    public class MongoBookDBContext : IMongoBookDBContext
    {
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        private IMongoDatabase _db { get; set; }
        //public MongoBookDBContext(IDbConfiguration configuration)
        //{
        //    dbConfiguration = configuration;
        //    var client = new MongoClient(dbConfiguration.ConnectionString);
        //    var database = client.GetDatabase(configuration.DataBaseName); 

        //    //dbCollection = database.GetCollection<Book>(configuration.BookCollectionName);
        //} 

        public MongoBookDBContext(IOptions<MangoDbSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DataBaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
