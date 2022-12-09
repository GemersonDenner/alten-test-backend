using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Entities
{
	public class Room : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public Room()
		{

		}
		
		public Room(string name, string description)
		{
			this.Name = name;
			this.Description = description;
		}
	}
}
