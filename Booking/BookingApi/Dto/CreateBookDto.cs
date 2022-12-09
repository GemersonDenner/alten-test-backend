using System.ComponentModel.DataAnnotations;

namespace BookingApi.Dto
{
	public class CreateBookDto
	{
		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }
	}
}
