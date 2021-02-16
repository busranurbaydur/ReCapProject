using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, ReCapDbContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from r in context.Rentals
                             join cus in context.Customers
                             on r.CustomerId equals cus.CustomerId
                             join u in context.Users
                             on cus.UserId equals u.UserId
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             select new RentalDetailDto
                             { 
                                 CarId = c.CarId,
                                 CustomerId = cus.CustomerId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 RentalId = r.RentalId,
                                 UserName = u.FirstName

                             };
                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            throw new NotImplementedException();
        }
    }
}
