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
	public class RoomConfiguration : IEntityTypeConfiguration<Room>
	{
		public void Configure(EntityTypeBuilder<Room> builder)
		{
			builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
			builder.Property(p => p.Name).IsRequired();
			builder.Property(p => p.Description).IsRequired();
		}
	}
}
