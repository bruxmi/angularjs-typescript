using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces.Repository.Command
{
	/// <summary>
	///     This DynamicSqlCommandRepository class shall be used to offer data manipulation operations with dynamic sql statements.
	/// </summary>
	public interface IDynamicSqlCommandRepository
	{
		/// <summary>
		/// Asynchronously fires a dynamic sql command against the database.
		/// </summary>
		/// <param name="sql">The sql command.</param>
		/// <param name="parameters">The sql parameters.</param>
		Task<int> SqlCommandAsync(string sql, params object[] parameters);
	}
}
