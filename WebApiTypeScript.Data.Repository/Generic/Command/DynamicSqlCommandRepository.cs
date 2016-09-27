using System;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces.Repository.Command;

namespace WebApiTypeScript.Data.Repository.Generic.Command
{
    public class DynamicSqlCommandRepository : IDynamicSqlCommandRepository
    {
        public DynamicSqlCommandRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; }

        public async Task<int> SqlCommandAsync(string sql, params object[] parameters)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            var result = await DbContext.Database.ExecuteSqlCommandAsync(sql, parameters);
            return result;
        }
    }
}