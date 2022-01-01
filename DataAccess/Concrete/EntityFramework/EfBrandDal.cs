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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                var addedToDb = reCapDbContext.Entry(entity);
                addedToDb.State = EntityState.Added;
                reCapDbContext.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetCarsByBrandId(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapDbContext reCapDbContext = new ReCapDbContext())
            {
                return reCapDbContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public List<Brand> GetCarsByColorId(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
