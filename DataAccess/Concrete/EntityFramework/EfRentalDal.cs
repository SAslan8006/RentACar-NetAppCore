using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join re in context.Rentals
                             on ca.CarId equals re.CarId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             from u in context.Users
                             join cu in context.Customers
                             on u.UserId equals cu.UserId
                             select new RentalDetailDto
                             {
                                 CarId = ca.CarId,
                                 BrandId = b.BrandId,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 ModelName = ca.ModelName,
                                 RentalId = re.RentalId,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 CustomerName = u.FirstName,
                                 CustomerLastname = u.LastName

                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
