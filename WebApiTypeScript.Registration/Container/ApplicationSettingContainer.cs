using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WebApiTypeScript.Business.ApplicationSettings;
using WebApiTypeScript.Core;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;
using WebApiTypeScript.Data.ApplicationSettingsContext;
using WebApiTypeScript.Data.Repository.Generic;
using WebApiTypeScript.Data.Repository.Generic.Query;

namespace WebApiTypeScript.Registration.Container
{
	public class ApplicationSettingContainer: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AppSettingContext>().InstancePerLifetimeScope();
			builder.RegisterType<ApplicationSettingQueryService>().As<IApplicationSettingQueryService>().InstancePerLifetimeScope();
			builder.RegisterType<ConnectionStringQueryService>().As<IConnectionStringQueryService>().InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof(RepositoryApplicationSettingsInitializer<>)).As(typeof(IRepositoryApplicationSettingInitializer<>)).InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof(QuerySettingsRepositoryApplicationSettingsSetting<>)).As(typeof(IQueryApplicationSettingsRepository<>)).InstancePerLifetimeScope();
			base.Load(builder);
		}
	}
}
