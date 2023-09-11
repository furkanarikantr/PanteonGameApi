using Core.DataAccess.MongoRepository;
using Core.Entity;
using Core.Settings;
using DataAccess.Concrete.MongoDb.Context;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MongoDb
{
    public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepositoryBase(IOptions<MongoSettings> settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<TEntity>();
        }

        public void Delete(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<TEntity>.Filter.Eq("Id", objectId);
            _collection.FindOneAndDelete(filter);
        }

        public TEntity Get(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<TEntity>.Filter.Eq("Id", objectId);
            var data = _collection.Find(filter).FirstOrDefault();
            return data;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return _collection.Find(_ => true).ToList();
            }
            else
            {
                return _collection.Find(filter).ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public void Update(TEntity entity, string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<TEntity>.Filter.Eq("Id", objectId);
            _collection.ReplaceOne(filter, entity);
        }
    }
}
