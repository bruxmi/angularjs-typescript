using Autofac;
using WebApiTypeScript.Registration.Container;

namespace WebApiTypeScript.Registration
{
	public static class Bootstrapper
	{
		public static void InitializeProduction(this ContainerBuilder builder)
		{
			builder.RegisterModule(new GenericRepositoryContainer());
			builder.RegisterModule(new UserContainer());
		}
	}
}
