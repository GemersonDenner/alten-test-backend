using Booking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Specifications
{
	public class BookWithRangeDateFilterSpecification : BaseSpecification<Book>
	{
		public BookWithRangeDateFilterSpecification(BookSpecParams bookSpecParams) :
			base
				(x =>
				x.StartDate.Date >= bookSpecParams.startDate.Date
				&&
				x.EndDate.Date <= bookSpecParams.endDate.Date
				)
		{ }
	}
}
