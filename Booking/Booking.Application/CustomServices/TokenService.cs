﻿using Booking.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Booking.Core.Entities.Identity;

namespace Booking.Application.CustomServices
{
	public class TokenService : ITokenService
	{

		private readonly IConfiguration _configuration;
		private readonly SymmetricSecurityKey _Key;
		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
			_Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
		}

		public string CreateToken(BookingUser bookingUser)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, bookingUser.Email),
				new Claim(ClaimTypes.GivenName, bookingUser.DisplayName)
			};
			var cred = new SigningCredentials(_Key, SecurityAlgorithms.HmacSha512Signature);
			var TokenDesc = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Audience = bookingUser.DisplayName,
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = cred,
				Issuer = _configuration["Token:Issuer"],

			};
			var tokenhandler = new JwtSecurityTokenHandler();
			var token = tokenhandler.CreateToken(TokenDesc);
			return tokenhandler.WriteToken(token);
		}
	}
}
