using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Entities
{
	public class Book:BaseEntity
	{
		public DateTime BookDate { get; set; } = DateTime.Now;
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int NumberDays { get; set; }
		public string UserEmail { get; set; }


		public Book()
		{

		}

		public Book(string userEmail, DateTime startDate, DateTime endDate)
		{
			this.UserEmail = userEmail;
			this.StartDate = startDate;
			this.EndDate = endDate;
			this.NumberDays = (startDate - endDate).Days + 1;
		}


	}
}
