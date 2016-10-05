using Autofac;
using WebApiTypeScript.Core.Interfaces.Services;
using WebApiTypeScript.Core.Interfaces.Services.Query;
using WebApiTypeScript.Core.Services;

namespace WebApiTypeScript.Registration.Container
{
	public class MiscContainer: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AppConfigurationService>().As<IAppConfigurationService>().InstancePerLifetimeScope();
			builder.RegisterType<ExceptionHandlerService>().As<IExceptionHandlerService>();
			builder.RegisterType<ContextService>().As<IContextService>().InstancePerLifetimeScope();
			base.Load(builder);
		}
	}
}
