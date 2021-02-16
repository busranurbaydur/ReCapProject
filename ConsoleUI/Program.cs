using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

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

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAllColors().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            colorManager.Add(new Color { ColorName = "Saks Mavisi" });
            colorManager.Add(new Color { ColorName = "Saman Sarısı" });

        }

        

        
        
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand { BrandName = "TOGG"});
            brandManager.Add(new Brand { BrandName = "Tofaş" });

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("ARABA MARKALARI");

            foreach (var brand in brandManager.GetAllBrands().Data)
            {
                Console.WriteLine(brand.BrandId + "  " + brand.BrandName);

            }

        }

        // private static void UserTest()
        //{carManager.Add(new Car { DailyPrice = 225, BrandId = 3, ColorId = 5, Description = " otomatik ", ModelYear = 2022 });
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    var result = userManager.Add(new User { FirstName = "burcu", LastName = "kara", Email = "bkk@gmail.com", Password = "12bk" });

        //}

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { DailyPrice = 225, BrandId = 3, ColorId = 5, Description = " otomatik ", ModelYear = 2022 });
            carManager.Add(new Car { DailyPrice = 500, BrandId = 6, ColorId = 2, Description = " lüks ", ModelYear = 2019 });


            var result = carManager.GetCarDetails();
            
            Console.WriteLine(" ---KİRALIK ARAÇ LİSTESİ VE FİYATLARI--- ");
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "  " + car.CarName + "  " + car.ColorName + " Günlük Fiyatı " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }

    }
}
