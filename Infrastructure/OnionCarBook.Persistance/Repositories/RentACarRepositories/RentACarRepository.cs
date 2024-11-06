using Microsoft.EntityFrameworkCore;
using OnionCarBook.Application.Interfaces.RentACarInterfaces;
using OnionCarBook.Domain.Entities;
using OnionCarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistance.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _context;

        public RentACarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)  // Expression<Func<RentACar, bool>> türü ile filtreleme için bir lambda ifadesi veya LINQ ifadesi kabul edilir. 
        {
            var values = await _context.RentACars.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
            return values;
        }
    }
}


// Include(x => x.Car) ile RentACar nesneleri ile ilişkili Car nesnelerini getirir.
// ThenInclude(y => y.Brand) ile Car nesneleri ile ilişkili Brand nesnelerini de dahil eder.
// Bu Include ve ThenInclude zincirlemesi, Entity Framework Core’un " Eager Loading " özelliğidir ve RentACar verisi ile ilişkili Car ve Brand verilerini tek bir sorguda getirmeyi sağlar.