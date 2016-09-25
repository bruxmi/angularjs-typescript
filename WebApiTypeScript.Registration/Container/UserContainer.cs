using Autofac;
using WebApiTypeScript.Business;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Registration.Container
{
	public class UserContainer: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<UserQueryService>().As<IUserQueryService>().InstancePerLifetimeScope();
			base.Load(builder);
		}
	}
}
