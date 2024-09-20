using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Commands.FeatureCommands
{
    public class UpdateFeatureCommand : IRequest
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
    }
}


//IRequest: MediatR kütüphanesinde kullanılan bir arayüzdür. Bu, bir "istek" (request) olduğunu belirtir ve bu isteğin 
//bir "işleyici" (handler) tarafından işleneceği anlamına gelir. IRequest'in generic olmayan hali kullanıldığında, 
//bu komut bir sonuç döndürmez, yani void gibi çalışır. Eğer bir sonuç döndürmek isteseydik, IRequest<T> kullanırdık.



//Örneğin, güncellenmesi gereken bir özellik olabilir ve bu özelliğin ID'si ve yeni adı bu komut ile gönderilir. 
//Handler (işleyici) sınıfı bu veriyi alır ve veritabanındaki ilgili kaydı günceller.