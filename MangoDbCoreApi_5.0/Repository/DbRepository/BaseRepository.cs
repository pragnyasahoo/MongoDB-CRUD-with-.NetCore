using MangoDbCoreApi_5.Models.Abstract;
using MangoDbCoreApi_5.Repository.Repository.DbContext;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5.Repository.DbRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection; 

        protected BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
           // _dbCollection = context.GetCollection<TEntity>(typeof(TEntity).Name); //if the collection name is same as model class
            _dbCollection = context.GetCollection<TEntity>();
        }  

        public async Task<TEntity> CreateAsync(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            await _dbCollection.InsertOneAsync(obj);
            return obj;

        }

        public Task DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            return _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));
        }

        public Task<List<TEntity>> GetAllBookAsync()
        {
            return _dbCollection.Find(Builders<TEntity>.Filter.Empty).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var objectId = new ObjectId(id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public Task UpdateAsync(string Id, TEntity obj)
        {
            return _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", new ObjectId(Id)), obj);
        }

    }
}
