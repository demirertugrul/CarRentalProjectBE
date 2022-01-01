using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemoryDal
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars =  new List<Car> {
                new Car {CarId=1,BrandId=1,ColorId=1,CarName="Tesla",
                    ModelYear=new DateTime(2022,1,1),DailyPrice=50000,Descriptions="Tesla S"},
                new Car {CarId=1,BrandId=1,ColorId=2,CarName="Tesla",
                    ModelYear=new DateTime(2012,1,1),DailyPrice=150000,Descriptions="Tesla 3"},
                new Car {CarId=2,BrandId=2,ColorId=3,CarName="BMW",
                    ModelYear=new DateTime(2020,1,1),DailyPrice=40000,Descriptions="BWM X"},
                new Car {CarId=3,BrandId=3,ColorId=4,CarName="Porsche",
                    ModelYear=new DateTime(2015,1,1),DailyPrice=75000,Descriptions="Porsche A"},
                new Car {CarId=4,BrandId=4,ColorId=5,CarName="Ferrari",
                    ModelYear=new DateTime(2017,1,1),DailyPrice=125000,Descriptions="Ferrari L"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetByld(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public List<Car> GetCarsByBrandId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
        }
    }

}
