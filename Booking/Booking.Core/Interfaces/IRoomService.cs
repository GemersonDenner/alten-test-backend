using Booking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Interfaces
{
	public interface IRoomService
	{
		Task<IReadOnlyList<Room>> GetRoomAsync();
		Task<Room> CreateRoomAsync(string name, string decription);
	}
}
