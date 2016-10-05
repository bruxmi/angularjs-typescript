using Autofac;
using Owin;
using WebApiTypeScript.Core;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Middlewares;

namespace WebApiTypeScript.Extensions
{
	public static class AppBuilderExtension
	{
		private static readonly ILog Logger = AppContainer.Current.Resolve<ILog>();


		public static void UseRequestId(this IAppBuilder app)
		{
			Logger.Info("Using request identifier.");

			app.Use<RequestIdMiddleware>();
		}
	}
}