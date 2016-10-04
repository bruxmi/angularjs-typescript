using Autofac;
using WebApiTypeScript.Core;

namespace WebApiTypeScript.Registration.Container
{
	public class LoggerContainer: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterInstance(SerligLogger.Current);
			base.Load(builder);
		}
	}
}
