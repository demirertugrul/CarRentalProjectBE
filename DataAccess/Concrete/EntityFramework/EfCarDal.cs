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
                                    on cars.ColorId equals colors.Id
                                    join brands in context.Brands
                                    on cars.BrandId equals brands.Id
                                    select new CarDetailDto
                                    {
                                        Id = cars.Id,
                                        CarName = cars.ModelName,
                                        BrandId = brands.Id,
                                        BrandName = brands.Name,
                                        ColorId = colors.Id,
                                        ColorName = colors.ColorName,
                                        DailyPrice = cars.DailyPrice,
                                        ModelYear = cars.ModelYear,
                                        Descriptions = cars.Descriptions,
                                        MinFindeksScore = cars.MinFindeksScore,
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
            var result = GetCarDetails().Where(c => c.Id == carId);
            return result.ToList();
        }

        public List<CarDetailDto> GetCarsByFilterWithDetails(int brandId, int colorId)
        {
            var result = GetCarDetails().Where(c => c.BrandId == brandId && c.ColorId == colorId);
            return result.ToList();
        }
    }
}