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
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetLastRentalByCarId(int carId);
        IDataResult<List<Rental>> GetByCustomerId(int customerId);
        IDataResult<List<RentalDetailDto>> GetRentalDetail();
        IDataResult<Rental> GetById(int id);
    }
}
