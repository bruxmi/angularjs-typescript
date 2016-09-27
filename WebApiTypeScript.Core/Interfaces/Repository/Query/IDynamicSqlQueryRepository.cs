using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces.Repository.Query
{
	/// <summary>
	/// This DynamicSqlQueryRepository provides methods to fire dynamically created sql statements against a database to query data.
	/// </summary>
	/// <typeparam name="T">The type of class you want to query.</typeparam>
	public interface IDynamicSqlQueryRepository<T>
		 where T : class
	{
		/// <summary>
		/// Asynchronously creates a raw SQL query that will return elements of the given type. 
		/// The type can be any type that has properties that match the names of the columns returned from the query, 
		/// or can be a simple primitive type. The type does not have to be an entity type.
		/// </summary>
		/// <param name="sql">The sql statement</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>Returns the queried result.</returns>
		Task<List<T>> SqlQueryAsync(string sql, params object[] parameters);

		/// <summary>
		// Asynchronously creates a raw SQL query and returns an object of the type of TReturnType.
		// The returned TReturnType object is filled (via reflection) with the queried information of the sql statement.
		/// </summary>
		/// <typeparam name="TReturnType">The type of the return type.</typeparam>
		/// <param name="sql">The sql statement.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>Returns the queried result.</returns>
		Task<List<TReturnType>> SqlQueryAsync<TReturnType>(string sql, params object[] parameters);
	}
}
