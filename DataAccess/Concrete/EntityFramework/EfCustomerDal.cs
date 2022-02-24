using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EntityFrameworkRepositoryBase<Customer, CarDbContext>, ICustomerDal
    {

        public CustomerDetailDto GetCustomerDetailsByUserId(int userId)
        {
            using (var context = new CarDbContext())
            {
                var result = from customer in context.Customers.Where(c => c.UserId == userId)
                             join findeksScore in context.Findeks
                             on customer.FindeksId equals findeksScore.Id
                             select new CustomerDetailDto
                             {
                                 Id = customer.Id,
                                 CompanyName = customer.CompanyName,
                                 FindeksPoint = findeksScore.Score
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
