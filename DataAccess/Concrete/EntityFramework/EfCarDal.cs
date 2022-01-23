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
    public class EfCarDal : EntityFrameworkRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var getCarDetails = from cars in context.Cars
                                    join colors in context.Colors
                                    on cars.ColorId equals colors.ColorId
                                    join brands in context.Brands
                                    on cars.BrandId equals brands.BrandId
                                    select new CarDetailDto
                                    {
                                        CarId = cars.CarId,
                                        CarName = cars.CarName,
                                        BrandId = brands.BrandId,
                                        BrandName = brands.BrandName,
                                        ColorId = colors.ColorId,
                                        ColorName = colors.ColorName,
                                        DailyPrice = cars.DailyPrice,
                                        ModelYear = cars.ModelYear,
                                        Descriptions = cars.Descriptions,
                                        ImagePath = (from im in context.CarImages where im.CarId == cars.CarId select im.ImagePath).FirstOrDefault()
                                    };

                return getCarDetails.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByBrandIdWithDetails(int brandId)
        {
            var result = GetCarDetails().Where(b => b.BrandId == brandId);
            return result.ToList();
        }

        public List<CarDetailDto> GetCarsByColorIdWithDetails(int colorId)
        {
            var result = GetCarDetails().Where(b => b.ColorId == colorId);
            return result.ToList();
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            var result = GetCarDetails().Where(c => c.CarId == carId);
            return result.ToList();
        }
    }
}