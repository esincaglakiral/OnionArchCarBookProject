using MediatR;
using OnionCarBook.Application.Features.Mediator.Queries.FeatureQueries;
using OnionCarBook.Application.Features.Mediator.Results.FeatureResults;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    // GetFeatureQuery sorgusunu işleyen sınıf.
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository; // Veritabanı işlemlerini yapacak repository.

        public GetFeatureQueryHandler(IRepository<Feature> repository)  // Repository bağımlılığını constructor ile enjekte ediyoruz.

        {
            _repository = repository; // Repository'yi atıyoruz.
        }


        // Sorguyu işleyen Handle metodu.
        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync(); // Veritabanından tüm özellikleri (Feature) asenkron olarak alıyoruz.


            // Veritabanından alınan özellikleri, sorgu sonucuna uygun bir formata dönüştürüyoruz.
            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureID = x.FeatureID,
                Name = x.Name
            }).ToList(); // Liste olarak döndür.
        }
    }
}



//MediatR, CQRS desenini uygularken bir aracı olarak kullanılabilir. Yani, CQRS ile komut ve sorguları ayırırken MediatR bu işlemleri yönetmek için devreye girer. Sonuç olarak:

//MediatR, CQRS yapısını yönetmek için kullanılabilir.
//CQRS, uygulamanın veri işleme mantığını daha düzenli hale getiren bir desen sunar.