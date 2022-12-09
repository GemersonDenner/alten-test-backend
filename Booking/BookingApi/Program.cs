using Booking.Infrastructure.Data;
using Booking.Infrastructure.identity;
using BookingApi.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookingContext>(options =>
			options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<IdentityContext>(options =>
			options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultIdentityConnection")));

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddIdentityService(builder.Configuration);


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

app.UseAuthorization();

app.MapControllers();
SeedData.Initialize(app.Services);
app.Run();


public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
		using (var serviceScope = serviceProvider.CreateScope())
		{
			var contextBook = serviceScope.ServiceProvider.GetService<BookingContext>();
			// auto migration
			contextBook.Database.EnsureCreated();

			var contextIdentity = serviceScope.ServiceProvider.GetService<IdentityContext>();
			// auto migration
			contextIdentity.Database.EnsureCreated();
		}
	}
}