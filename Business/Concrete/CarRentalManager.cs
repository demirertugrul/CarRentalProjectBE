using Business.Abstract;
using Business.Constrants;
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

        public CarRentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<List<CarRentalDto>> getRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDto>>(_rentalDal.GetAddedRental(),Messages.GetRentals);
        }
    }
}
