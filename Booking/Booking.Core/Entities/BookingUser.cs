﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Booking.Core.Entities
{
	public  class BookingUser : IdentityUser
	{
		public string DisplayName { get; set; }
	}
}
