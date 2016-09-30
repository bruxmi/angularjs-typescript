using System;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiTypeScript.Business;
using WebApiTypeScript.Core;
using WebApiTypeScript.Core.Extensions;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.Repository.Generic;
using WebApiTypeScript.Registration;
using WebApiTypeScript.Registration.Container;

namespace WebApiTypeScript
{
    public class WebApiApplication : System.Web.HttpApplication
    {
		protected void Application_Error(object sender, EventArgs e)
		{
			var exception = this.Server.GetLastError();
			this.Server.ClearError();
			AppExceptionHandler.Current.Handle(exception);
			exception.Rethrow();
		}

		protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
			var builder = AppContainer.Create();
			Bootstrapper.InitializeProduction(builder);
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			AppContainer.Factory = builder.Build();
			AppConfiguration.Factory = AppContainer.Current.Resolve<IAppConfigurationService>();
			var loggerBuilder = new ContainerBuilder();
			loggerBuilder.RegisterModule(new LoggerContainer());
			AppContainer.UpdateContainer(loggerBuilder);
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(AppContainer.Current);
			GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
