using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryDal;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Car car1 = new Car { CarId=2,BrandId=1,ColorId=3,CarName="Tesla",
                ModelYear=new DateTime(2022,1,1),DailyPrice=55200,Descriptions="Tesla X"
            };

            List<Car> cars = new List<Car> { 
                new Car {CarId=1,BrandId=1,ColorId=1,CarName="Tesla",
                    ModelYear=new DateTime(2022,1,1),DailyPrice=50000,Descriptions="Tesla S"},
                new Car {CarId=2,BrandId=1,ColorId=2,CarName="Tesla",
                    ModelYear=new DateTime(2012,1,1),DailyPrice=150000,Descriptions="Tesla 3"},
                new Car {CarId=3,BrandId=2,ColorId=1,CarName="BMW",
                    ModelYear=new DateTime(2020,1,1),DailyPrice=40000,Descriptions="BWM X"},
                new Car {CarId=4,BrandId=4,ColorId=3,CarName="Porsche",
                    ModelYear=new DateTime(2015,1,1),DailyPrice=75000,Descriptions="Porsche A"},
                new Car {CarId=5,BrandId=3,ColorId=4,CarName="Ferrari",
                    ModelYear=new DateTime(2017,1,1),DailyPrice=125000,Descriptions="Ferrari L"},
            };
            carManager.Add(car1);

            Console.Write("---------------");
            foreach(var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Descriptions);
            }

        }
    }
}
