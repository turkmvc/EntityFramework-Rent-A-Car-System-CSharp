using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            BrandTest();
            ColorTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 3, CarName = "B", ModelYear = 2021, DailyPrice = 2500, Description = "AMGv2" });
            carManager.Update(new Car { Id = 4, BrandId = 2, ColorId = 1, CarName = "B", ModelYear = 2019, DailyPrice = 18000, Description = "TSI" });
            carManager.Delete(new Car { Id = 6 });

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Name: " + car.CarName + 
                            "      Car Brand Name: " + car.BrandName +
                            "      Car Color Name: " + car.ColorName +
                            "      Car Daily Price: " + car.DailyPrice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand { BrandId = 4, BrandName = "Bentley" });
            brandManager.Update(new Brand { BrandId = 3, BrandName = "Audi" });
            brandManager.Delete(new Brand { BrandId = 4 });

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Brand Id: " + brand.BrandId + "      Brand Name: " + brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { ColorId = 6, ColorName = "Yellow" });
            colorManager.Update(new Color { ColorId = 3, ColorName = "Red" });
            colorManager.Delete(new Color { ColorId = 6 });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color Id: " + color.ColorId + "      Color Name: " + color.ColorName);
            }
        }

        

    }
}
