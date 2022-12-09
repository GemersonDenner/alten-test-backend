using Booking.Core.Entities.Identity;
using Booking.Infrastructure.identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookingApi.Extensions
{
	public static class IdentityServiceExtensions
	{
		public static IServiceCollection AddIdentityService(this IServiceCollection services,
			IConfiguration _configuration)
		{
			var builder = services.AddIdentityCore<BookingUser>();

			builder = new IdentityBuilder(builder.UserType, builder.Services);
			builder.AddEntityFrameworkStores<IdentityContext>();
			builder.AddSignInManager<SignInManager<BookingUser>>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
				options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
						ValidIssuer = _configuration["Token:Issuer"],
						ValidateIssuer = true,
						ValidateAudience = false

					};
				});
			return services;
		}
	}
}
