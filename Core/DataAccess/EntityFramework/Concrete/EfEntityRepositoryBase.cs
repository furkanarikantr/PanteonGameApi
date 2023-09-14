using Core.DataAccess.EntityFramework.Abstract;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework.Concrete
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEfEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            using (TContext context = new TContext())
            {
                var query = context.Set<TEntity>().AsQueryable<TEntity>();

                if (includes != null)
                {
                    query = includes(query).Where(filter);
                }
                else
                {
                    query = query.Where(filter);
                }
                return query.SingleOrDefault();
            }
        }

        public void Insert(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            using (TContext context = new TContext())
            {
                var query = context.Set<TEntity>().AsQueryable<TEntity>();
                if (filter == null && includes == null)
                {
                    return query.ToList();
                }
                else
                {
                    if (filter != null && includes == null)
                    {

                        query = query.Where(filter);

                    }
                    else if (includes != null && filter == null)
                    {
                        query = includes(query);
                    }
                    else
                    {
                        query = includes(query).Where(filter);
                    }
                }
                return query.ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatededEntity = context.Entry(entity);
                updatededEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
