﻿using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        //[TransactionScopeAspect]
        //[PerformanceAspect(5)]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        //[PerformanceAspect(5)]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        //[CacheAspect]
        public IResult Get()
        {
            return new SuccessDataResult<Car>(_carDal.Get(), Messages.CarListed);
        }

        //[CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsAllListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.CarId == carId));
        }

        //[CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailGot);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByCarId(carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdWithDetails(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByBrandIdWithDetails(brandId));

        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorIdWithDetails(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByColorIdWithDetails(colorId));

        }

        public IDataResult<List<CarDetailDto>> GetCarsByFilterWithDetails(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByFilterWithDetails(brandId,colorId), Messages.CarsAllListed);
        }

        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
