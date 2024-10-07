using Microsoft.EntityFrameworkCore;
using OnionCarBook.Application.Interfaces.CarPricingInterfaces;
using OnionCarBook.Domain.Entities;
using OnionCarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 2).ToList();
            return values;
            //pricing id =2 olanlar günlük fiyatlar oluyor dolayısıyla arçların günlük fiyatları listelenir burda
        }
    }
}
