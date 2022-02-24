using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {

        IFindeksDal _findeksDal;

        public FindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IResult Add(Findeks findeks)
        {
            _findeksDal.Add(findeks);
            return new SuccessResult(Messages.FindeksAdded);
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);
            return new SuccessResult(Messages.FindeksDeleted);
        }

        public IDataResult<Findeks> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(fc => fc.CustomerId == customerId));
        }

        public IResult Update(Findeks findeks)
        {
            _findeksDal.Update(findeks);
            return new SuccessResult(Messages.FindeksUpdated);
        }
    }
}
