﻿using Core.DataAccess.EntityFramework;
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
    public class EfRentalDal : EntityFrameworkRepositoryBase<Rental, ReCapDbContext>, IRentalDal
    {

        public List<CarRentalDto> GetAddedRental()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var addCarRent = from cars in context.Cars
                                    join rentals in context.Rentals
                                    on cars.CarId equals rentals.CarId
                                    join costm in context.Costumers 
                                    on rentals.CostumerId equals costm.CostumerId
                                    join users in context.Users
                                    on costm.UserId equals users.Id
                                    select new CarRentalDto
                                    {
                                       CarId = cars.CarId,
                                       CostumerId = costm.CostumerId,
                                       CompanyName = costm.CompanyName,
                                       UserNameFirstName= users.FirstName,
                                       RentDate = rentals.RentDate,
                                       ReturnDate= rentals.ReturnDate
                                    };
                return addCarRent.ToList();
            }
        }


    }
}