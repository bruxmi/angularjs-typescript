using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Extensions;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Data.Repository.Generic
{
	public abstract class QueryRepositoryBase<T>: IQueryRepository<T>
		where T : class, IEntity
	{
		private readonly IDbSet<T> dbSet;

		protected QueryRepositoryBase(IRepositoryInitializer<T> initializer)
		{
			this.dbSet = initializer.GetDbSet();
		}

		public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
		{
			return await this.CreateQueryable().AnyAsync(predicate);
		}

		public virtual async Task<int> CountAsync()
		{
			return await this.CreateQueryable().CountAsync();
		}

		public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
		{
			return await this.CreateQueryable().CountAsync(predicate);
		}

		public virtual async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
		{
			return await this.CreateQueryable()
				.Where(predicate)
				.ToListAsync();
		}

		public virtual async Task<List<T>> FindAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes)
		{
			return await this.CreateQueryable(includes).Where(predicate).ToListAsync();
		}

		public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
		{
			return await this.CreateQueryable().FirstAsync(predicate);
		}

		public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
		{
			return await this.CreateQueryable().FirstOrDefaultAsync(predicate);
		}

		public virtual async Task<List<T>> GetAllAsync()
		{
			return await this.CreateQueryable().ToListAsync();
		}

		public virtual async Task<List<T>> GetAllOrderedByAsync<TO>(Expression<Func<T, TO>> orderBy)
		{
			return await this.CreateQueryable()
				.OrderBy(orderBy)
				.ToListAsync();
		}

		public virtual async Task<List<T>> GetAllWithPagingAsync<TO>(
			Expression<Func<T, TO>> orderBy,
			int pageIndex,
			int pageSize)
		{
			return await this.CreateQueryable()
				.OrderBy(orderBy)
				.Skip(pageIndex * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public virtual async Task<List<T>> GetFilteredWithPagingAsync<TO>(
			Expression<Func<T, bool>> filter,
			Expression<Func<T, TO>> orderBy,
			int pageIndex = 0,
			int pageSize = int.MaxValue)
		{
			return await this.CreateQueryable()
				.Where(filter)
				.OrderBy(orderBy)
				.Skip(pageIndex * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public virtual async Task<List<T>> GetWithPagingAndOrderAsync<TO>(
			Expression<Func<T, TO>> orderBy,
			bool isDescending,
			int pageIndex = 0,
			int pageSize = int.MaxValue)
		{
			return await this.CreateQueryable()
				.OrderByWithDirection(orderBy, isDescending)
				.Skip(pageIndex * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public virtual async Task<List<T>> GetFilteredWithPagingAsync<TI, TO>(
			Expression<Func<T, bool>> filter,
			Expression<Func<T, TO>> orderBy,
			int pageIndex = 0,
			int pageSize = int.MaxValue,
			params Expression<Func<T, TI>>[] includes)
		{
			return await this.CreateQueryable(includes)
				.Where(filter)
				.OrderBy(orderBy)
				.Skip(pageIndex * pageSize)
				.Take(pageSize).ToListAsync();
		}

		public virtual async Task<List<T>> GetFilteredtWithPagingAndOrderAsync<TO>(
			Expression<Func<T, bool>> filter,
			Expression<Func<T, TO>> orderBy,
			bool isDescending,
			int pageIndex = 0,
			int pageSize = int.MaxValue)
		{
			return await this.CreateQueryable()
				.Where(filter)
				.OrderByWithDirection(orderBy, isDescending)
				.Skip(pageIndex * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public virtual async Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
		{
			return await this.CreateQueryable().SingleAsync(predicate);
		}

		public virtual async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
		{
			return await this.CreateQueryable().SingleOrDefaultAsync(predicate);
		}

		public virtual async Task<T> SingleOrDefaultAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes)
		{
			return await this.CreateQueryable(includes).SingleOrDefaultAsync(predicate);
		}

		public async Task<T> FirstAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes)
		{
			return await this.CreateQueryable(includes).FirstAsync(predicate);
		}

		public async Task<T> FirstOrDefaultAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes)
		{
			return await this.CreateQueryable(includes).FirstOrDefaultAsync(predicate);
		}

		public async Task<List<T>> GetAllAsync<TI>(params Expression<Func<T, TI>>[] includes)
		{
			return await this.CreateQueryable(includes).ToListAsync();
		}

		public async Task<List<T>> GetAllOrderedByAsync<TO, TI>(
			Expression<Func<T, TO>> orderBy,
			params Expression<Func<T, TI>>[] includes)
		{
			return await this.CreateQueryable(includes)
				.OrderBy(orderBy)
				.ToListAsync();
		}

		public async Task<List<T>> GetAllWithPagingAsync<TI, TO>(
			Expression<Func<T, TO>> orderBy,
			int pageIndex,
			int pageSize,
			params Expression<Func<T, TI>>[] includes)
		{
			return await this.CreateQueryable(includes)
				.OrderBy(orderBy)
				.Skip(pageIndex * pageSize)
				.Take(pageSize).ToListAsync();
		}

		public async Task<T> SingleAsync<TI>(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, TI>>[] includes)
		{
			return await this.CreateQueryable(includes).SingleAsync(predicate);
		}

		private IQueryable<T> CreateQueryable()
		{
			return this.dbSet.AsNoTracking();
		}

		private IQueryable<T> CreateQueryable<TI>(params Expression<Func<T, TI>>[] includes)
		{
			var queryable = this.dbSet.AsNoTracking();
			queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
			return queryable;
		}
	}
}
