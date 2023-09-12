using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.MongoRepository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Get(string id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        void Insert(TEntity entity);
        void Update(TEntity entity, string id);
        void Delete(string id);
    }
}
