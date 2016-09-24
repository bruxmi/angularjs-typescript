using Autofac;
using WebApiTypeScript.Business;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Registration.Container
{
	public static class AppContainerUser
	{
		public static void InjectUser(this ContainerBuilder container)
		{
			container.RegisterType<UserQueryService>().As<IUserQueryService>().InstancePerRequest();
		}
	}
}
