using Microsoft.EntityFrameworkCore;
using OnionCarBook.Application.Interfaces.StatisticsInterfaces;
using OnionCarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()  //toplam yazar sayısını döndürür
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily() //Günlük kiralama fiyatlarının ortalamasını hesaplar.
        {
            //Select Avg(Amount) from CarPricings where PricingID=(Select PricingID From Pricings Where Name='Günlük')
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();  //Pricing tablosunda adı "Günlük" olan fiyatlandırma türüne ait PricingID değeri sorgulanır ve id değişkenine atanır.
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);  //CarPricings tablosunda, PricingID değeri günlük fiyatlandırmaya (id değişkenine eşit) olan kayıtlar arasından Amount (fiyat) sütununun ortalama değeri hesaplanır.
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()  //Aylık kiralama fiyatlarının ortalamasını hesaplar.
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly() //Haftalık kiralama fiyatlarının ortalamasını hesaplar.
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount() //toplam blog sayısını döndürür.
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public string GetBlogTitleByMaxBlogComment()  //En fazla yorum alan blog başlığını döndürür.
        {
            //Select Top(1) BlogId,Count(*) as 'Sayi' From Comments Group By BlogID Order By Sayi Desc 
            var values = _context.Comments.GroupBy(x => x.BlogID).
                              Select(y => new
                              {
                                  BlogID = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();  //OrderByDescending ile yorum sayısına göre azalan bir sıralama yapılır. Bu sıralama, en fazla yoruma sahip blogun en üst sırada olmasını sağlar.
            string blogName = _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefault();  //Take(1).FirstOrDefault() ifadesi ile en fazla yoruma sahip olan ilk blog seçilir.

            return blogName;
        }

        public int GetBrandCount()  // toplam araç marka sayısını döndürür.
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetBrandNameByMaxCar()  //En fazla sayıda araca sahip markanın adını döndürür.
        {
            //Select Top(1) BrandId,Count(*) as 'ToplamArac' From Cars Group By Brands.Name  order By ToplamArac Desc

            var values = _context.Cars.GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()  //Günlük kiralama fiyatı en yüksek olan aracın marka ve model bilgilerini döndürür.
        {
            //Select * From CarPricings where Amount=(Select Max(Amount) From CarPricings where PricingID=3)
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();  //Pricing tablosunda "Günlük" isimli fiyatlandırmanın PricingID değerini alınıyor
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Max(x => x.Amount);  //CarPricings tablosunda, PricingID'si günlük fiyatlandırmaya eşit olan kayıtlar arasından en yüksek Amount (fiyat) değeri bulunur. Bu değer, günlük kiralama fiyatı en yüksek olan araca aittir.
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault(); //CarPricings tablosunda, yukarıda bulunan en yüksek fiyata sahip (Amount değeri) kayıt arasından, ilgili aracın CarID bilgisi seçilir. Bu adım, en pahalı günlük kiralık aracın ID'sini belirler.
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault(); //Bu sorgu sonucunda, aracın marka adı ve model bilgisi birleştirilir ve brandModel değişkenine atanır.
            return brandModel;  //brandModel değeri, yani en yüksek günlük kiralama fiyatına sahip aracın marka ve modeli metot tarafından döndürülür.
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()  //Günlük kiralama fiyatı en düşük olan aracın marka ve model bilgilerini döndürür.
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()  //toplam araç sayısını döndürür.
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()  //Elektrik yakıtlı araç sayısını döndürür.
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()  //Benzin veya dizel yakıtlı araç sayısını döndürür.
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()  //1000 km veya altında olan araç sayısını döndürür.
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTranmissionIsAuto()  //Otomatik şanzımana sahip araç sayısını döndürür
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()  //toplam lokasyon sayısını döndürür.
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
