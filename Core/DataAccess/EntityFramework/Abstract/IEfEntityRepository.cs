using Core.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> List(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        T Get(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
