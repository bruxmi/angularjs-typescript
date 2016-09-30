using Autofac;
using WebApiTypeScript.Core;

namespace WebApiTypeScript.Registration.Container
{
	public class LoggerContainer: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterInstance(AppLogger.Current);
			base.Load(builder);
		}
	}
}
