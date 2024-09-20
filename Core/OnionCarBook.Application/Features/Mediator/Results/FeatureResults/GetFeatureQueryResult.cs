using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Results.FeatureResults
{
    // Sorgu sonucunda döndürülecek olan özellik (Feature) bilgilerini tutan sınıf.

    public class GetFeatureQueryResult
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
    }
}
