using System;
using WebApiTypeScript.Data.AppContext;

namespace WebApiTypeScript.IntegrationTest
{
    public class DatabaseFixture: IDisposable
    {
        private WebApiTypeScriptContext DbContext { get; }
    

        public DatabaseFixture()
        {
            this.DbContext = new WebApiTypeScriptContext();
        }

        public WebApiTypeScriptContext GetDbContext()
        {
            return this.DbContext;
        }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }
    }
}
