using Booking.Core.Entities;
using Booking.Core.Exceptions;
using Booking.Core.Interfaces;
using Booking.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.CustomServices
{
	public class BookService : IBookService
	{
		private readonly IUnitOfWork _unitOfWork;

		public BookService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Book> CreateBookAsync(string userEmail, DateTime startDate, DateTime endDate)
		{
			if (endDate > startDate)
			{
				throw new BusinessException("Invalid Dates");
			}

			var checkExistBookBetweenDate = await this.GetBookAsync(startDate, endDate);
			if(checkExistBookBetweenDate != null)
			{
				throw new BusinessException("Already exist an Booking between this dates");
			}

			if ((endDate - startDate).Days > 3)
			{
				throw new BusinessException("Sorry, you only can schedule less then 4 days.");
			}
			
			var newBook = new Book(userEmail, startDate, endDate);
			_unitOfWork.repository<Book>().Add(newBook);

			var result = await _unitOfWork.Complete();
			if (result <= 0)
			{
				return null;
			}
			return newBook;
		}

		public async Task<bool> DeleteBookAsync(string userEmail, int idBook)
		{
			var bookExistent = await this.GetBookAsync(userEmail, idBook);
			if(bookExistent == null)
			{
				throw new BusinessException("Book not found");
			}

			_unitOfWork.repository<Book>().Delete(bookExistent.First());
			var result = await _unitOfWork.Complete();
			if (result <= 0)
			{
				return false;
			}
			return true;
		}

		public async Task<IReadOnlyList<Book>> GetBookAsync()
		{
			return await _unitOfWork.repository<Book>().GetAllAsync();
		}

		public async Task<IReadOnlyList<Book>> GetBookAsync(DateTime startDate, DateTime endDate)
		{
			var bookParams = new BookSpecParams { startDate = startDate, endDate = endDate};
			var spec = new BookWithEmailFilterSpecification(bookParams);
			return await _unitOfWork.repository<Book>().ListAsync(spec);
		}

		public async Task<IReadOnlyList<Book>> GetBookAsync(string emailUser)
		{
			var bookParams = new BookSpecParams { emailUser = emailUser };
			var spec = new BookWithEmailFilterSpecification(bookParams);
			return await _unitOfWork.repository<Book>().ListAsync(spec);
		}
		private async Task<IReadOnlyList<Book>> GetBookAsync(string emailUser, int idBook)
		{
			var bookParams = new BookSpecParams { emailUser = emailUser, Id = idBook };
			var spec = new BookWithIdAndEmailFilterSpecification(bookParams);
			return await _unitOfWork.repository<Book>().ListAsync(spec);
		}

		public async Task<Book> UpdateBookAsync(string userEmail, int idBook, DateTime startDate, DateTime endDate)
		{
			var bookExistent = await this.GetBookAsync(userEmail, idBook);
			if (bookExistent == null)
			{
				throw new BusinessException("Book not found");
			}
			var bookUpdated = bookExistent.First();
			bookUpdated.StartDate = startDate;
			bookUpdated.EndDate = endDate;

			_unitOfWork.repository<Book>().Update(bookUpdated);
			var result = await _unitOfWork.Complete();
			if (result <= 0)
			{
				return null;
			}
			return bookUpdated;
		}
	}
}
