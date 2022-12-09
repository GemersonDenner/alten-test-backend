using Booking.Core.Entities;
using Booking.Core.Entities.Identity;
using Booking.Core.Interfaces;
using BookingApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Specialized;

namespace BookingApi.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : BaseApiController
	{

		public IRoomService RoomService { get; }

		public RoomController(IRoomService roomService)
		{
			RoomService = roomService;
		}

		[HttpGet(nameof(GetRooms))]
		public async Task<ActionResult<IReadOnlyList<Room>>> GetRooms()
		{
			var rooms = await RoomService.GetRoomAsync();
			return Ok(rooms);
		}

		[HttpPost(nameof(CreateRoom))]
		public async Task<ActionResult<Room>> CreateRoom([FromHeader]string name, [FromHeader] string description)
		{
			var user = HttpContext.User.RetriveEmailFromPrincipal();
			var room = await RoomService.CreateRoomAsync(name, description);
			if (room == null)
			{
				return BadRequest("Mensage error");
			}
			return Ok(room);

		}
	}
}
