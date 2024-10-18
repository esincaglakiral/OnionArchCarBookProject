using OnionCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Application.Interfaces.CarInterfaces;
using OnionCarBook.Persistance.Context;
using OnionCarBook.Persistance.Repositories;
using OnionCarBook.Persistance.Repositories.CarRepositories;

using OnionCarBook.Application.Services;
using OnionCarBook.Application.Interfaces.BlogInterfaces;
using OnionCarBook.Persistance.Repositories.BlogRepositories;
using OnionCarBook.Application.Interfaces.CarPricingInterfaces;
using OnionCarBook.Persistance.Repositories.CarPricingRepositories;
using OnionCarBook.Application.Interfaces.TagCloudInterfaces;
using OnionCarBook.Persistance.Repositories.TagCloudRepositories;
using OnionCarBook.Application.Features.RepositoryPattern;
using OnionCarBook.Persistance.Repositories.CommentRepositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//AddScoped Methods Registration
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));




builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();




builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();




builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();




builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();



builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();



builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();



builder.Services.AddApplicationService(builder.Configuration);  //MediatR k�t�phanesini entegre ettik (ServiceRegistiration i�in) 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
