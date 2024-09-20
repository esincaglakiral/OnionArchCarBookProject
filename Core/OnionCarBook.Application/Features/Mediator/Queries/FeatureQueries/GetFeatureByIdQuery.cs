using MediatR;
using OnionCarBook.Application.Features.Mediator.Results.FeatureResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
    {
        // Belirli bir ID ile özellik (Feature) bilgisini almak için kullanılan sorgu sınıfı.
        public int Id { get; set; }

        public GetFeatureByIdQuery(int id)  // Constructor, sorguyu başlatırken ID'yi alır.
        {
            Id = id; // Özelliğin ID'sini ayarlar.
        }
    }
}
