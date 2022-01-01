using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.CarName.Length>=2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception("Araba ismi 2 karakterden ve fiyatı 0'dan fazla olmalıdır");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public Car Get()
        {
            return _carDal.Get();
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetCarsByBrandId(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetCarsByColorId(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
