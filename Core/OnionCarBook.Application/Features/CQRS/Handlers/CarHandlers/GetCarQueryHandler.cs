using OnionCarBook.Application.Features.CQRS.Results.CarResults;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository; // Repository dependency injection
        }


        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                BrandID = x.BrandID,
                BigImageUrl = x.BigImageUrl,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}




//MediatR ve CQRS Arasındaki Farklar:

//MediatR bir kütüphane olup, uygulamanızda mediator deseni ile mesajların (komutlar, sorgular, olaylar) işlenmesini sağlar. 
//Tüm talepler bir "handler" tarafından işlenir.

//CQRS ise bir mimari desen olup, uygulamanızdaki komut ve sorgu işlemlerini birbirinden ayırarak daha ölçeklenebilir 
//ve yönetilebilir bir yapı sunar. CQRS, veriyi okuma (query) ve yazma (command) işlemlerini ayrı ele alır.
