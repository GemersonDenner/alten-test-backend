using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Specifications
{
	public class BookSpecParams
	{
		public string emailUser { get; set; }

		public DateTime startDate { get; set; }

		public DateTime endDate { get; set; }

		public int Id { get; set; }
	}
}
