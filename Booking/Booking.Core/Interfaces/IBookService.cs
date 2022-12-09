using Booking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Interfaces
{
	public interface IBookService
	{
		Task<IReadOnlyList<Book>> GetBookAsync();
		Task<IReadOnlyList<Book>> GetBookAsync(DateTime startDate, DateTime endDate);
		Task<IReadOnlyList<Book>> GetBookAsync(string emailUser);
		Task<Room> CreateBookAsync(string userEmail, DateTime startDate, DateTime endDaten);
	}
}
