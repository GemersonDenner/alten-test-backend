using Booking.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookingApi.Extensions
{
    public static class UserManagerExtension
	{
		public static async Task<BookingUser> FindByEmailFromClaimPrincipal(
			this UserManager<BookingUser> input, ClaimsPrincipal user)
		{
			var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
			return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
		}
	}
}
