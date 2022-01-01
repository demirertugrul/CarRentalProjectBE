using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                var addedToDb = reCapDbContext.Entry(entity);
                addedToDb.State = EntityState.Added;
                reCapDbContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                var deletedToDb = reCapDbContext.Entry(entity);
                deletedToDb.State = EntityState.Deleted;
                reCapDbContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                return reCapDbContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter=null)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                return filter == null
                    ? reCapDbContext.Set<Car>().ToList()
                    : reCapDbContext.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetCarsByBrandId(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                return reCapDbContext.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetCarsByColorId(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                return reCapDbContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                var updatedToDb = reCapDbContext.Entry(entity);
                updatedToDb.State = EntityState.Modified;
                reCapDbContext.SaveChanges();
            }
        }
    }
}
