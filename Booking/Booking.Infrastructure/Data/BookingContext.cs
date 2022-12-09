using Booking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Data
{
	public class BookingContext : DbContext
	{
		public BookingContext(DbContextOptions<BookingContext> options) : base(options)
		{

		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Room> Rooms { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

	}
}
