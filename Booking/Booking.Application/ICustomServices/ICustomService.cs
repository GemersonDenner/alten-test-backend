using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.ICustomServices
{
	public interface ICustomService<T>
	{
		IEnumerable<T> GetAll();
		void FindById(int Id);
		void Insert(T entity);
		Task<T> Update(T entity);
		void Delete(T entity);
	}
}
