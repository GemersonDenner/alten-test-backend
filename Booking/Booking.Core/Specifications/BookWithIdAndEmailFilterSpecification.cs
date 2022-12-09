using Booking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Specifications
{
	public class BookWithIdAndEmailFilterSpecification : BaseSpecification<Book>
	{
		public BookWithIdAndEmailFilterSpecification(BookSpecParams bookSpecParams) :
			base
				(x =>
				x.Id == bookSpecParams.Id
				&&
				x.UserEmail.Trim().ToUpper() == bookSpecParams.emailUser.Trim().ToUpper()
				)
		{ }
	}
}
