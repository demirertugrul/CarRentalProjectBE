using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EntityFrameworkRepositoryBase<Rental, CarDbContext>, IRentalDal
    {

        public List<CarRentalDto> GetAddedRental()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var addCarRent = from cars in context.Cars
                                    join rentals in context.Rentals
                                    on cars.CarId equals rentals.CarId
                                    join custm in context.Customers 
                                    on rentals.CostumerId equals custm.CostumerId
                                    join users in context.Users
                                    on custm.UserId equals users.Id
                                    select new CarRentalDto
                                    {
                                       CarId = cars.CarId,
                                       CostumerId = custm.CostumerId,
                                       CompanyName = custm.CompanyName,
                                       UserNameFirstName= users.FirstName,
                                       RentDate = rentals.RentDate,
                                       ReturnDate= rentals.ReturnDate
                                    };
                return addCarRent.ToList();
            }
        }


    }
}
