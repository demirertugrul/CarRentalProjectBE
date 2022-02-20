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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _costumerDal;

        public CustomerManager(ICustomerDal costumerDal)
        {
            _costumerDal = costumerDal;
        }

        public IResult Add(Customer costumer)
        {
            _costumerDal.Add(costumer);
            return new SuccessResult("Müşteri eklendi");
        }

        public IResult Delete(Customer costumer)
        {
            _costumerDal.Delete(costumer);
            return new SuccessResult("Müşteri silindi");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_costumerDal.GetAll(), "Müşteriler listelendi");
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_costumerDal.Get(c=>c.Id==id),"Müşteri listelendi");
        }

        public IResult Update(Customer costumer)
        {
            _costumerDal.Update(costumer);
            return new SuccessResult("Müşteri güncellendi");
        }
    }
}
