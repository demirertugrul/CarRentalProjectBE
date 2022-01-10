using Business.Concrete;
using Core.Utilities.Helpers.FileHelperFolder;
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
            //FrontEnd_Data
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
            //CarManagerTest();
            //ColorManagerTest();
            //BrandManagerTest();
            //CarRentalManagerTest();
        }
        private static void CarRentalManagerTest()
        {
            CarRentalManager carRentalManager = new CarRentalManager(new EfRentalDal());
            Rental rental = new Rental
            {
                //Id-> auto inc
                CarId = 3,
                CostumerId = 3,
                RentDate = new DateTime(2019,1,1)
            };
            carRentalManager.Add(rental);
            foreach (var rent in carRentalManager.getRentalDetails().Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4} / {5}", rent.CarId,rent.CostumerId,
                    rent.CompanyName,rent.UserNameFirstName,rent.RentDate,rent.ReturnDate);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand { BrandId = 5, BrandName = "MarsCar" };
            brandManager.Add(brand);
            var getById = brandManager.GetById(5);
            Console.WriteLine(getById.Data);
            brandManager.Delete(brand);
            foreach (var brands in brandManager.GetAll().Data)
            {
                Console.WriteLine(brands.BrandName);
            }
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var getById = colorManager.GetById(1);
            Console.WriteLine(getById.Data);
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new CarImageManager(new EfCarImageDal(),new FileHelperManager()));
            var getDetails = carManager.GetCarDetails();
            if (getDetails.Success)
            {
                Console.WriteLine(getDetails.Message);
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine("{0} / {1} / {2}", car.CarName, car.BrandName, car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(getDetails.Message);
            }
        }
    }
}
