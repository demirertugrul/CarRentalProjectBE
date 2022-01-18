using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CostumerManager : ICostumerService
    {
        ICostumerDal _costumerDal;

        public CostumerManager(ICostumerDal costumerDal)
        {
            _costumerDal = costumerDal;
        }

        public IResult Add(Costumer costumer)
        {
            _costumerDal.Add(costumer);
            return new SuccessResult("Müşteri eklendi");
        }

        public IResult Delete(Costumer costumer)
        {
            _costumerDal.Delete(costumer);
            return new SuccessResult("Müşteri silindi");
        }

        public IDataResult<List<Costumer>> GetAll()
        {
            return new SuccessDataResult<List<Costumer>>(_costumerDal.GetAll(), "Müşteriler listelendi");
        }

        public IDataResult<Costumer> GetById(int id)
        {
            return new SuccessDataResult<Costumer>(_costumerDal.Get(c=>c.CostumerId==id),"Müşteri listelendi");
        }

        public IResult Update(Costumer costumer)
        {
            _costumerDal.Update(costumer);
            return new SuccessResult("Müşteri güncellendi");
        }
    }
}
