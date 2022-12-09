using System.Security.Claims;

namespace BookingApi.Extensions
{
	public static class ClaimsPrincipalExtensions
	{
		public static string RetriveEmailFromPrincipal(this ClaimsPrincipal User)
		{
			return User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
		}
	}
}
