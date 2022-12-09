using System.ComponentModel.DataAnnotations;

namespace BookingApi.Dto
{
	public class UpdateBookDto
	{
		[Required]
		public int IdActual { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }
	}
}
