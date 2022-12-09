using Booking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Specifications
{
	public class BookWithEmailFilterSpecification : BaseSpecification<Book>
	{
		public BookWithEmailFilterSpecification(BookSpecParams bookSpecParams) :
			base
				(x =>
				x.UserEmail.Trim().ToUpper() == bookSpecParams.emailUser.Trim().ToUpper()
				)
		{ }
	}
}
