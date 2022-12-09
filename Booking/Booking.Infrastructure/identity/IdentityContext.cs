﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.identity
{
	public class IdentityContext : IdentityDbContext
	{
		public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
		{

		}

		protected IdentityContext()
		{
		}
	}
}
