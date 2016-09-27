using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.Repository.Generic;

namespace WebApiTypeScript.Registration.Container
{
	public class GenericRepositoryContainer: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<WebApiTypeScriptContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RepositoryAppInitializer<>)).As(typeof(IRepositoryInitializer<>)).InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof(QueryRepository<>)).As(typeof(IQueryRepository<>)).InstancePerLifetimeScope();
			base.Load(builder);
		}
	}
}
