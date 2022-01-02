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

            Car car1 = new Car {BrandId=1,ColorId=3,CarName="t",
                ModelYear=new DateTime(2022,1,1),DailyPrice=55200,Descriptions="Tesla X"
            };

            List<Car> cars = new List<Car> { 
                new Car {BrandId=1,ColorId=1,CarName="Tesla",
                    ModelYear=new DateTime(2022,1,1),DailyPrice=50000,Descriptions="Tesla S"},
                new Car {BrandId=1,ColorId=2,CarName="Tesla",
                    ModelYear=new DateTime(2012,1,1),DailyPrice=150000,Descriptions="Tesla 3"},
                new Car {BrandId=2,ColorId=1,CarName="BMW",
                    ModelYear=new DateTime(2020,1,1),DailyPrice=40000,Descriptions="BWM X"},
                new Car {BrandId=4,ColorId=3,CarName="Porsche",
                    ModelYear=new DateTime(2015,1,1),DailyPrice=75000,Descriptions="Porsche A"},
                new Car {BrandId=3,ColorId=4,CarName="Ferrari",
                    ModelYear=new DateTime(2017,1,1),DailyPrice=125000,Descriptions="Ferrari L"},
            };
            //carManager.Add(car1);
            for (int i = 0; i < cars.Count; i++)
            {
                carManager.Add(cars[i]);
            }

            Console.Write("------(-_-)-------");
            foreach(var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Descriptions);
            }

        }
    }
}
