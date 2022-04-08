using MangoDbCoreApi_5.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;
using MangoDbCoreApi_5.Models.Abstract;

namespace MangoDbCoreApi_5.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConfiguration dbConfiguration;

        private readonly IMongoCollection<Book> dbCollection;
        public BookRepository(IDbConfiguration configuration)
        {
            dbConfiguration = configuration;
            var client = new MongoClient(dbConfiguration.ConnectionString);
            var database = client.GetDatabase(configuration.DataBaseName);
            dbCollection = database.GetCollection<Book>(configuration.BookCollectionName);
        }
        public Task<List<Book>> GetAllBookAsync() => dbCollection.Find(book => true).ToListAsync();

        public Task<Book> GetByIdAsync(string id)
        {
            return dbCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await dbCollection.InsertOneAsync(book).ConfigureAwait(false);
            return book;
        }
        public Task DeleteAsync(string id)
        {
            return dbCollection.DeleteOneAsync(book => book.Id == id);

        } 
        public  Task UpdateAsync(string id, Book book)
        {
            return dbCollection.ReplaceOneAsync(c => c.Id == book.Id, book);
        }
    }
}
