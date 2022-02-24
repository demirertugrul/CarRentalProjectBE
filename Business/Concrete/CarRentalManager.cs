using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
    public class CarRentalManager : ICarRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;
        ICustomerDal _customerDal;
        IFindeksDal _findeksDal;

        public CarRentalManager(IRentalDal rentalDal, ICarDal carDal, ICustomerDal customerDal, IFindeksDal findeksDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
            _customerDal = customerDal;
            _findeksDal = findeksDal;
        }

        public IResult Add(Rental rental)
        {
            var result = CheckRentalDate(rental);
            if (result.Success)
            {
                if (CheckFindeksForRental(rental.CarId, rental.CustomerId).Success)
                {
                    _rentalDal.Add(rental);
                    return new SuccessResult(Messages.CarHired);
                }
                else
                {
                    return new ErrorResult(Messages.FindeksIsInsufficient);
                }

            }
            return new ErrorResult(result.Message);

        }

        private IResult CheckFindeksForRental(int carId, int customerId)
        {
            Car car = _carDal.Get(c => c.Id == carId);
            Customer customer = _customerDal.Get(cu => cu.Id == customerId);
            Findeks findeks = _findeksDal.Get(fc => fc.CustomerId == customer.Id);
            if (car.MinFindeksScore <= findeks.Score)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckRentalDate(Rental rental)
        {
            var rentals = _rentalDal.GetAll().Where(r => r.ReturnDate.CompareTo(rental.RentDate) > 0).ToList();
            if (rentals.Count != 0)
            {
                return new ErrorResult(Messages.CarNotReturned);
            }
            return new SuccessResult();

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetLastRentalByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll().Where(r => r.CarId == carId).LastOrDefault());
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll().Where(r => r.CustomerId == customerId).ToList()); ;
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
