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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                var addedToDb = reCapDbContext.Entry(entity);
                addedToDb.State = EntityState.Added;
                reCapDbContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                var deletedToDb = reCapDbContext.Entry(entity);
                deletedToDb.State = EntityState.Deleted;
                reCapDbContext.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                return reCapDbContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                return filter == null
                    ? reCapDbContext.Set<Color>().ToList()
                    : reCapDbContext.Set<Color>().Where(filter).ToList();
            }
        }

        public List<Color> GetCarsByBrandId(Expression<Func<Color, bool>> filter)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                return reCapDbContext.Set<Color>().Where(filter).ToList();
            }
        }

        public List<Color> GetCarsByColorId(Expression<Func<Color, bool>> filter)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                return reCapDbContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
