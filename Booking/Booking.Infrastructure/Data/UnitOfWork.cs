using Booking.Core.Entities;
using Booking.Core.Interfaces;
using Booking.Infrastructure.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly BookingContext _storeContext;
		private Hashtable _repositories;

		public UnitOfWork(BookingContext storeContext)
		{
			_storeContext = storeContext;
		}
		public async Task<int> Complete()
		{
			return await _storeContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_storeContext.Dispose();
		}

		public IGenericRepository<TEntity> repository<TEntity>() where TEntity : BaseEntity
		{
			if (_repositories == null) _repositories = new Hashtable();
			var Type = typeof(TEntity).Name;
			if (!_repositories.ContainsKey(Type))
			{
				var repositiryType = typeof(GenericRepository<>);
				var repositoryInstance = Activator.CreateInstance(
					repositiryType.MakeGenericType(typeof(TEntity)), _storeContext);
				_repositories.Add(Type, repositoryInstance);
			}
			return (IGenericRepository<TEntity>)_repositories[Type];
		}
	}
}
