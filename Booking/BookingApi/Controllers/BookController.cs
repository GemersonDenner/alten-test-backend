using Booking.Application.CustomServices;
using Booking.Core.Entities;
using Booking.Core.Interfaces;
using BookingApi.Dto;
using BookingApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : BaseApiController
	{

		public IBookService BookService { get; }

		public BookController(IBookService bookService)
		{
			BookService = bookService;
		}

		/*
		 
		 Task<IReadOnlyList<Book>> GetBookAsync();
		Task<IReadOnlyList<Book>> GetBookAsync(DateTime startDate, DateTime endDate);
		Task<IReadOnlyList<Book>> GetBookAsync(string emailUser);
		Task<Book> CreateBookAsync(string userEmail, DateTime startDate, DateTime endDate);
		Task<bool> DeleteBookAsync(string userEmail, int idBook);
		Task<Book> UpdateBookAsync(string userEmail, int idBook, DateTime startDate, DateTime endDate);

		 */

		[HttpGet(nameof(GetMyBooking))]
		public async Task<ActionResult<IReadOnlyList<Book>>> GetMyBooking()
		{
			
			var user = HttpContext.User.RetriveEmailFromPrincipal();
			var books = await BookService.GetBookAsync(user);
			return Ok(books);
		}

		[HttpGet(nameof(GetByPeriod))]
		public async Task<ActionResult<IReadOnlyList<Book>>> GetByPeriod([FromHeader]DateTime startdate, [FromHeader] DateTime enddate)
		{
			var books = await BookService.GetBookAsync(startdate.Date, enddate.Date);
			return Ok(books);
		}

		[HttpPost(nameof(Create))]
		public async Task<ActionResult<Book>> Create(CreateBookDto createBookDto)
		{ 
			var user = HttpContext.User.RetriveEmailFromPrincipal();
			var book = await BookService.CreateBookAsync(user, createBookDto.StartDate, createBookDto.EndDate);
			if (book == null)
			{
				return BadRequest("Mensage error");
			}
			return Ok(book);

		}

		[HttpPut(nameof(Update))]
		public async Task<ActionResult<Book>> Update(UpdateBookDto updateBookDto)
		{
			var user = HttpContext.User.RetriveEmailFromPrincipal();
			var book = await BookService.UpdateBookAsync(user, updateBookDto.IdActual, updateBookDto.StartDate, updateBookDto.EndDate);
			if (book == null)
			{
				return BadRequest("Mensage error");
			}
			return Ok(book);

		}

		[HttpDelete(nameof(Remove))]
		public async Task<ActionResult<Book>> Remove([FromHeader] int idBookingItem)
		{
			var user = HttpContext.User.RetriveEmailFromPrincipal();
			var result = await BookService.DeleteBookAsync(user, idBookingItem);
			return Ok(result);
		}


	}
}
