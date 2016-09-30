using Autofac;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.Repository.Generic;
using WebApiTypeScript.Data.Repository.Generic.Query;

namespace WebApiTypeScript.Registration.Container
{
	public class GenericRepositoryContainer : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<WebApiTypeScriptContext>().InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof (RepositoryWebApiTypeScriptInitializer<>)).As(typeof (IRepositoryInitializer<>)).InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof (QueryRepository<>)).As(typeof(IQueryRepository<>)).InstancePerLifetimeScope();
			base.Load(builder);
		}
	}
}