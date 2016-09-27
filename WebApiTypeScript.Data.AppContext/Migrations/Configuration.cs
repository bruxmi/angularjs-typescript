namespace WebApiTypeScript.Data.AppContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiTypeScriptContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApiTypeScript.Data.AppContext.WebApiTypeScriptContext";
        }

        protected override void Seed(WebApiTypeScriptContext context)
        {

        }
    }
}
