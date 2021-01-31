﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _carList;
        public InMemoryCarDal()
        {
            _carList = new List<Car> 
            {
                new Car{ Id = 1, BrandId= 1, ColorId=1, DailyPrice= 80, Description= "Nissan Micra Kırmızı Renk", ModelYear=2005},
                new Car{ Id = 2, BrandId= 2, ColorId=2, DailyPrice= 150, Description= "Ford Fiesta Beyaz Renk", ModelYear=2018},
                new Car{ Id = 3, BrandId= 2, ColorId=3, DailyPrice= 130, Description= "Ford Focus Siyah Renk", ModelYear=2015},
                new Car{ Id = 4, BrandId= 3, ColorId=3, DailyPrice= 210, Description= "BMW d320 Siyah Renk", ModelYear=2011},
                new Car{ Id = 5, BrandId= 4, ColorId=2, DailyPrice= 135, Description= "Toyota Corolla Beyaz Renk", ModelYear=2016},

            };
        }
        public void Add(Car car)
        {
            _carList.Add(car);
        }

        public void Delete(Car car)
        {
           Car carToDelete = _carList.SingleOrDefault(c =>car.Id ==car.Id);
            _carList.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {
            return _carList;
        }
        public List<Car> GetById(int Id)
        {
            return _carList.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _carList.SingleOrDefault(c => car.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice= car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}