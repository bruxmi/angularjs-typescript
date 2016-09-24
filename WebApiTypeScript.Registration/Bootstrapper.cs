using Autofac;
using WebApiTypeScript.Registration.Container;

namespace WebApiTypeScript.Registration
{
	public static class Bootstrapper
	{
		public static void InitializeProduction(this ContainerBuilder builder)
		{
			AppContainerUser.InjectUser(builder);
		}
	}
}
