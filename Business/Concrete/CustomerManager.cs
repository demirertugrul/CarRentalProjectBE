using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IFindeksDal _findeksDal;

        public CustomerManager(ICustomerDal customerDal, IFindeksDal findeksDal)
        {
            _customerDal = customerDal;
            _findeksDal = findeksDal;
        }

        public IResult Add(Customer customer)
        {
            Customer newCustomer = _customerDal.Get(c => c.UserId == customer.UserId);
            Findeks findeks = new Findeks() { CustomerId = newCustomer.Id };
            int score = new Random().Next(500, 1900);
            findeks.Score = score;
            _findeksDal.Add(findeks);
            Findeks newFindeks = _findeksDal.Get(fs => fs.CustomerId == newCustomer.Id);
            newCustomer.FindeksId = newFindeks.Id;
            _customerDal.Update(newCustomer);
            return new SuccessResult();
        }

        public IResult AddUserId(User user)
        {
            Customer customer = new Customer { UserId = user.Id };
            _customerDal.Add(customer);
            Add(customer);
            return new SuccessResult();
        }

       

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(u => u.Id == id));
        }

        public IDataResult<CustomerDetailDto> GetCustomerDetailsByUserId(int userId)
        {
            return new SuccessDataResult<CustomerDetailDto>(_customerDal.GetCustomerDetailsByUserId(userId));
        }

        public IResult Update(CustomerUpdateDto customerUpdateDto)
        {
            var customerForUpdate = GetById(customerUpdateDto.CustomerId).Data;
            customerForUpdate.CompanyName = customerUpdateDto.CompanyName;
            _customerDal.Update(customerForUpdate);
            return new SuccessResult();
        }
    }
}
