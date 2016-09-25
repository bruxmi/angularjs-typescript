using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;
using WebApiTypeScript.Data.Repository.Generic;

namespace WebApiTypeScript.Registration.Container
{
	public class GenericRepositoryContainer: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterGeneric(typeof(RepositoryAppInitializer<>)).As(typeof(IRepositoryInitializer<>)).InstancePerRequest();
			builder.RegisterGeneric(typeof(QueryRepository<>)).As(typeof(IQueryRepository<>)).InstancePerRequest();
		}
	}
}
