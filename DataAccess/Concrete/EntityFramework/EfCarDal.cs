using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EntityFrameworkRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context = new  ReCapDbContext())
            {
                var getCarDetails = from cars in context.Cars
                                    join colors in context.Colors
                                    on cars.ColorId equals colors.ColorId
                                    join brands in context.Brands
                                    on cars.BrandId equals brands.BrandId
                                    select new CarDetailDto
                                    {
                                        CarName = cars.Descriptions,
                                        BrandName = brands.BrandName,
                                        ColorName = colors.ColorName,
                                        DailyPrice = cars.DailyPrice
                                    };

                return getCarDetails.ToList();
            }
        }
    }
}
