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

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var addCarRent = from rentals in context.Rentals
                                 join cars in context.Cars on rentals.CarId equals cars.Id
                                 join custm in context.Customers on rentals.CustomerId equals custm.Id
                                 join brands in context.Brands on cars.BrandId equals brands.Id
                                 join users in context.Users on custm.UserId equals users.Id
                                 select new RentalDetailDto
                                 {
                                     RentalId = rentals.Id,
                                     BrandName = brands.Name,
                                     CustomerName = users.FirstName + " " + users.LastName,
                                     RentDate = rentals.RentDate,
                                     ReturnDate = rentals.ReturnDate
                                 };
                return addCarRent.ToList();
            }
        }

        public List<Rental> GetCarIdAndReturnDate(int carId, DateTime? returnDate)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from rentals in context.Rentals where rentals.CarId == carId && rentals.ReturnDate == returnDate select rentals;
                return result.ToList();
            }
        }
    }
}
