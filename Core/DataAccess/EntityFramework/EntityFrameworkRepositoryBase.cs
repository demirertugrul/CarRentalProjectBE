using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EntityFrameworkRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class,IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext reCapDbContext = new TContext())
            {
                var addedToDb = reCapDbContext.Entry(entity);
                addedToDb.State = EntityState.Added;
                reCapDbContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext reCapDbContext = new TContext())
            {
                var deletedToDb = reCapDbContext.Entry(entity);
                deletedToDb.State = EntityState.Deleted;
                reCapDbContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapDbContext = new TContext())
            {
                return reCapDbContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext reCapDbContext = new TContext())
            {
                return filter == null
                    ? reCapDbContext.Set<TEntity>().ToList()
                    : reCapDbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetCarsByBrandId(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapDbContext = new TContext())
            {
                return reCapDbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetCarsByColorId(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapDbContext = new TContext())
            {
                return reCapDbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext reCapDbContext = new TContext())
            {
                var updatedToDb = reCapDbContext.Entry(entity);
                updatedToDb.State = EntityState.Modified;
                reCapDbContext.SaveChanges();
            }
        }
    }
}
