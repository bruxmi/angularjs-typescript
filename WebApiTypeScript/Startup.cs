using Microsoft.Owin;
using WebApiTypeScript;

[assembly: OwinStartup(typeof(WebApiTypeScript.Startup))]
namespace WebApiTypeScript
{
	using System;
	using Owin;
	using Core;
	using Core.Interfaces.Services;
	using Autofac;
	using Extensions;

	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			try
			{
				// Creates a unique ID per request to ease maintenance ('Correlation ID')
				app.UseRequestId();
			}

			catch (Exception exception)
			{
				AppContainer.Current.Resolve<IExceptionHandlerService>().Handle(exception);
				throw;
			}
		}
	}
}