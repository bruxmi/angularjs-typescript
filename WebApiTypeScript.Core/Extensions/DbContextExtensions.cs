using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Constants;
using WebApiTypeScript.Core.Enums;
using WebApiTypeScript.Core.Interfaces;

namespace WebApiTypeScript.Core.Extensions
{
	public static class DbContextExtensions
	{
		public static DbSet<T> GetDbSet<T>(this DbContext context)
			where T : class, IEntity
		{
			return (DbSet<T>)context
				.GetType()
				.GetProperties()
				.FirstOrDefault(p => p.PropertyType == typeof(DbSet<T>))
				?.GetValue(context, null);
		}

		/// <summary>
		/// Gets the build configuration by the context's connection string.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns>Returns the <see cref="BuildConfiguration"/> determined by the context's connection string.</returns>
		public static BuildConfiguration GetBuildConfiguration(this DbContext context)
		{
			var connectionString = context.Database.Connection.ConnectionString;
			if (connectionString.IndexOf(DbConstants.DEBUG_IDENTIFIER, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return BuildConfiguration.Debug;
			}

			// Default is release, since the database names in production are usually unknown to the developers
			return BuildConfiguration.Release;
		}
	}
}
