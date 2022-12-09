using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Specifications
{
	public class BaseSpecification<T> : ISpecifications<T>
	{
		public Expression<Func<T, bool>> Criteria { get; }
		public BaseSpecification()
		{

		}
		public BaseSpecification(Expression<Func<T, bool>> Criteria)
		{
			this.Criteria = Criteria;
		}
		public List<Expression<Func<T, object>>> Includes { get; }
		= new List<Expression<Func<T, object>>>();

		public Expression<Func<T, object>> OrderBy { get; private set; }

		public Expression<Func<T, object>> OrderByDescending { get; private set; }

		protected void AddInclude(Expression<Func<T, object>> includeExpression)
		{
			Includes.Add(includeExpression);
		}

		public void AddOrderBy(Expression<Func<T, object>> OrderByexpression)
		{
			OrderBy = OrderByexpression;
		}
		public void AddOrderByDecending(Expression<Func<T, object>> OrderByDecending)
		{
			OrderByDescending = OrderByDecending;
		}
	}
}
