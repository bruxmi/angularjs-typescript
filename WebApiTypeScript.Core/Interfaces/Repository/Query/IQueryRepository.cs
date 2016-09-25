using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces.Repository.Query
{
	public interface IQueryRepository<T>
		where T : class
	{
		Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

		Task<int> CountAsync();

		Task<int> CountAsync(Expression<Func<T, bool>> predicate);

		Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

		Task<List<T>> FindAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes);

		Task<T> FirstAsync(Expression<Func<T, bool>> predicate);

		Task<T> FirstAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes);

		Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

		Task<T> FirstOrDefaultAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes);

		Task<List<T>> GetAllAsync();

		Task<List<T>> GetAllAsync<TI>(params Expression<Func<T, TI>>[] includes);

		Task<List<T>> GetAllOrderedByAsync<TO>(Expression<Func<T, TO>> orderBy);

		Task<List<T>> GetAllOrderedByAsync<TO, TI>(
			Expression<Func<T, TO>> orderBy,
			params Expression<Func<T, TI>>[] includes);

		Task<List<T>> GetAllWithPagingAsync<TO>(
			Expression<Func<T, TO>> orderBy,
			int pageIndex,
			int pageSize);

		Task<List<T>> GetAllWithPagingAsync<TI, TO>(
			Expression<Func<T, TO>> orderBy,
			int pageIndex,
			int pageSize,
			params Expression<Func<T, TI>>[] includes);

		Task<List<T>> GetFilteredWithPagingAsync<TO>(
			Expression<Func<T, bool>> filter,
			Expression<Func<T, TO>> orderBy,
			int pageIndex = 0,
			int pageSize = int.MaxValue);

		Task<List<T>> GetWithPagingAndOrderAsync<TI>(
			Expression<Func<T, TI>> orderBy,
			bool isDescending,
			int pageIndex = 0,
			int pageSize = int.MaxValue);

		Task<List<T>> GetFilteredWithPagingAsync<TI, TO>(
			Expression<Func<T, bool>> filter,
			Expression<Func<T, TO>> orderBy,
			int pageIndex = 0,
			int pageSize = int.MaxValue,
			params Expression<Func<T, TI>>[] includes);

		Task<List<T>> GetFilteredtWithPagingAndOrderAsync<TI>(
			Expression<Func<T, bool>> filter,
			Expression<Func<T, TI>> orderBy,
			bool isDescending,
			int pageIndex = 0,
			int pageSize = int.MaxValue);

		Task<T> SingleAsync(Expression<Func<T, bool>> predicate);

		Task<T> SingleAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes);

		Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

		Task<T> SingleOrDefaultAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes);
	}
}
