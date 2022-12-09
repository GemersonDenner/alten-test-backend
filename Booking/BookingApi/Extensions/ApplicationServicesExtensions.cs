using Booking.Application.CustomServices;
using Booking.Core.Interfaces;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Extensions
{
	public static class ApplicationServicesExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<BookingContext, BookingContext>();
			//services.AddScoped<StoreContextSeed, StoreContextSeed>();
			//services.AddScoped<IProductRepository, ProductRepository>();
			//services.AddScoped<ICustomerBasket, BasketRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			//services.AddScoped<IOrderService, OrderService>();
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			
			return services;
		}
	}
}
