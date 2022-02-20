using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarRentalService
    {
        IResult Add(Rental rental);
        //IResult AddRentalWithDetails(RentalAddDto rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IResult SetReturnedById(int id);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        //public IDataResult<bool> IsRentable(int carId, DateTime rentDate, DateTime returnDate);
    }
}
