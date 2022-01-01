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

            Car car1 = new Car { CarId=1,BrandId=1,ColorId=3,CarName="X",
                ModelYear=new DateTime(2022,1,1),DailyPrice=55200,Descriptions="Tesla X"
            };
            Color color = new Color {ColorId=1,ColorName="Red"};
            Brand brand = new Brand {BrandId=1,BrandName="Tesla"};

            List<Car> cars = new List<Car> { 
                new Car {CarId=4,BrandId=4,ColorId=4,CarName="Tesla",
                    ModelYear=new DateTime(2022,1,1),DailyPrice=50000,Descriptions="Tesla S"},
                new Car {CarId=5,BrandId=5,ColorId=5,CarName="Tesla",
                    ModelYear=new DateTime(2012,1,1),DailyPrice=150000,Descriptions="Tesla 3"},
                new Car {CarId=6,BrandId=6,ColorId=6,CarName="BMW",
                    ModelYear=new DateTime(2020,1,1),DailyPrice=40000,Descriptions="BWM X"},
                new Car {CarId=7,BrandId=7,ColorId=7,CarName="Porsche",
                    ModelYear=new DateTime(2015,1,1),DailyPrice=75000,Descriptions="Porsche A"},
                new Car {CarId=8,BrandId=8,ColorId=8,CarName="Ferrari",
                    ModelYear=new DateTime(2017,1,1),DailyPrice=125000,Descriptions="Ferrari L"},
            };

            List<Brand> brands = new List<Brand> { 
                new Brand {BrandId=1,BrandName="Tesla"},
                new Brand {BrandId=2,BrandName="BWM"},
                new Brand {BrandId=3,BrandName="Ferrari"},
                new Brand {BrandId=4,BrandName="Porsche"},
            };

            List<Color> colors = new List<Color> { 
                new Color{ColorId=1,ColorName="Red"},
                new Color{ColorId=2,ColorName="White"},
                new Color{ColorId=3,ColorName="Black"},
                new Color{ColorId=4,ColorName="Blue"},
            };

            foreach (var car in carManager.GetAll())
            {
                //Console.WriteLine(car.Descriptions);

            }

            //carManager.Add(new Car
            //{
            //    CarId = 7,
            //    BrandId = 7,
            //    ColorId = 7,
            //    CarName = "Xaaaaaaaa",
            //    ModelYear = new DateTime(2015, 1, 1),
            //    DailyPrice = 175000,
            //    Descriptions = "X A"
            //});
            Console.Write("---------------");
            foreach(var car in carManager.GetCarsByColorId(8))
            {
                Console.WriteLine(car.Descriptions);
            }


        }
    }
}
