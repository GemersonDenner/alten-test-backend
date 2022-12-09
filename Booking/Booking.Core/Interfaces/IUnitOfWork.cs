using Booking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<TEntity> repository<TEntity>() where TEntity : BaseEntity;
		Task<int> Complete();
	}
}
