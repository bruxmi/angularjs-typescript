using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Extensions;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Repository.Query;


namespace WebApiTypeScript.Data.Repository.Generic.Query
{
    public class DynamicSqlQueryRepository<T> : IDynamicSqlQueryRepository<T>
                where T : class, IEntity
    {
	    private readonly DbContext dbContext;

	    public DynamicSqlQueryRepository(DbContext dbContext)
	    {
		    this.dbContext = dbContext;
	    }

	    public async Task<List<T>> SqlQueryAsync(string sql, params object[] parameters)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            List<T> result;
			var dbSet = this.dbContext.GetDbSet<T>();

			// If T is an entity, the stored procedure must be accessed via the matching DbSet in order to enable lazy loading.
			if (dbSet != null)
            {
                // Optimization: The tracking is deactivated, since the DbContext just lives inside the request lifetime 
                // and subsequent updates are performed within a separate request / with a separate DbContext.
                result = await dbSet.SqlQuery(sql, parameters).AsNoTracking().ToListAsync();
            }
            // If T is just a helper class, just access the stored procedure directly via the database since no matching DbSet exists on the DbContext.
            else
            {
                result = await this.dbContext.Database.SqlQuery<T>(sql, parameters).ToListAsync();
            }

            return result;
        }

        // Calls the passed stored procedures and returns an object of the type of TReturnType.
        // The returned TReturnType object is filled (via reflection) with the queryed information of the stored procedure.
        public async Task<List<TReturnType>> SqlQueryAsync<TReturnType>(string sql, params object[] parameters)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            var result = await this.dbContext.Database.SqlQuery(typeof(TReturnType), sql, parameters).ToListAsync();
            return result.Cast<TReturnType>().ToList();
        }
    }
}
