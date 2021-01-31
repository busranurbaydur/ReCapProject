using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine( " ---KİRALIK ARAÇ LİSTESİ VE FİYATLARI--- ");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " " + car.ModelYear + " " + " Model Günlük Ücreti" + " " + car.DailyPrice + " TL " );
            }

            
        }
    }
}
