using System;
using System.Text;
using WebApiTypeScript.Core.Extensions;
using WebApiTypeScript.Data.AppContext;

namespace WebApiTypeScript.IntegrationTest
{
    public class DatabaseFixtureWithCleanUpEntities: IDisposable
    {
        private WebApiTypeScriptContext DbContext { get; }


        public DatabaseFixtureWithCleanUpEntities()
        {
            this.DbContext = new WebApiTypeScriptContext();
        }

        public WebApiTypeScriptContext GetDbContext()
        {
            return this.DbContext;
        }

        public void Dispose()
        {
            DeleteEntities();
            this.DbContext.Dispose();
        }

        private void DeleteEntities()
        {
            var assembly = typeof(WebApiTypeScriptContext).Assembly;
            var builder = new StringBuilder();
            builder.Append(assembly.GetManifestResourceText(DbConstants.CONTEXT_CLEANUP_RESOURCE));
            var sql = builder.ToString();
            DbContext.Database.ExecuteSqlCommand(sql);
        }
    }
}
