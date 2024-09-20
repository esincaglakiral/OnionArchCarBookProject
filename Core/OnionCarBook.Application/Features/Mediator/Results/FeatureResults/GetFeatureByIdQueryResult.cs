using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Results.FeatureResults
{
    // Belirli bir özellik ID'sine göre sorgu sonucunu taşıyan sınıf.

    public class GetFeatureByIdQueryResult
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
    }
}
