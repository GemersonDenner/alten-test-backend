using Booking.Core.Entities;
using Booking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.CustomServices
{
	public class RoomService : IRoomService
	{
		private readonly IUnitOfWork _unitOfWork;

		public RoomService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Room> CreateRoomAsync(string name, string decription)
		{
			var newRoom = new Room(name, decription);
			_unitOfWork.repository<Room>().Add(newRoom);

			var result = await _unitOfWork.Complete();
			if(result <= 0)
			{
				return null;
			}
			return newRoom;
		}

		public async Task<IReadOnlyList<Room>> GetRoomAsync()
		{
			return await _unitOfWork.repository<Room>().GetAllAsync();
		}
	}
}
