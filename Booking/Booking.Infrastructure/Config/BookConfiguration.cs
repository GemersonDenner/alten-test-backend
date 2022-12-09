using Booking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Config
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.Property(p=> p.Id).IsRequired().ValueGeneratedOnAdd();
			builder.Property(p => p.UserEmail).IsRequired();
			builder.Property(p => p.StartDate).IsRequired();
			builder.Property(p => p.EndDate).IsRequired();
			builder.Property(p => p.BookDate).IsRequired();
			builder.Property(p => p.NumberDays).IsRequired();
		}
	}
}
