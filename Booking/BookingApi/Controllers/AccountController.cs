using Booking.Core.Entities.Identity;
using Booking.Core.Interfaces;
using BookingApi.Dto;
using BookingApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AccountController : BaseApiController
	{
		private readonly SignInManager<BookingUser> _signInManager;
		private readonly UserManager<BookingUser> _userManager;
		private readonly ITokenService _tokenService;

		public AccountController(SignInManager<BookingUser> signInManager,
			UserManager<BookingUser> userManager, ITokenService tokenService)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_tokenService = tokenService;
		}

		[Authorize]
		[HttpGet(nameof(GetCurruntUser))]
		public async Task<ActionResult<UserDto>> GetCurruntUser()
		{
			var user = await _userManager.FindByEmailFromClaimPrincipal(HttpContext.User);
			return new UserDto
			{
				DisplayName = user.DisplayName,
				Token = _tokenService.CreateToken(user),
				Email = user.Email

			};
		}

		[HttpGet("emailexists")]
		public async Task<ActionResult<bool>> CheckEmialExistAsync([FromQuery] string Email)
		{
			return await _userManager.FindByEmailAsync(Email) != null;
		}

		[HttpPost(nameof(Login))]
		public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
		{
			var user = await _userManager.FindByEmailAsync(loginDto.Email);
			if (user == null) return Unauthorized();

			var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
			if (!result.Succeeded) return Unauthorized();
			return new UserDto
			{
				Email = user.Email,
				DisplayName = user.DisplayName,
				Token = _tokenService.CreateToken(user)
			};
		}

		[HttpPost(nameof(Register))]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			if (CheckEmialExistAsync(registerDto.Email).Result.Value)
			{
				return BadRequest(new
				{
					Errors = new
					[] { "Email is already in use" }
				});
			}
			var user = new BookingUser
			{
				DisplayName = registerDto.DisplayName,
				Email = registerDto.Email,
				UserName = registerDto.Email
			};
			var result = await _userManager.CreateAsync(user, registerDto.Password);
			if (!result.Succeeded) return BadRequest();
			return new UserDto
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = _tokenService.CreateToken(user)

			};
		}
	}
}
