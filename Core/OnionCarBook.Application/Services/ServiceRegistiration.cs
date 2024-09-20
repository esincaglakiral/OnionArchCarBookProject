using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Services
{
    public static class ServiceRegistiration //Bu sınıf, statik bir sınıf olup, uygulama servislerini kaydetmek için uzantı metodu sağlar.
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)  //Bu, extension method (uzantı metodu) olup, IServiceCollection üzerinde çalışır. 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));  // MediatR kütüphanesini bağımlılık konteynerine ekler. MediatR, komutlar ve sorgular ile handler (işleyici) sınıfları arasındaki iletişimi yönetir.
        }
    }
}


//Bu Kod Uygulamada servis kayıtlarını kolaylaştırmak ve özellikle MediatR kütüphanesinin entegre edilmesini sağlamak için yazılmıştır. 
//Bu sayede, uygulamanın CQRS yapısını kullanarak MediatR ile komutları ve sorguları yönetmek mümkün hale gelir.
