using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using WebApiTypeScript.Core.Constants;
using WebApiTypeScript.Core.Enums;
using WebApiTypeScript.Core.Extensions;

namespace WebApiTypeScript.Data.AppContext.Migrations
{
	using ApplicationSettingsContext;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;


	public sealed class Configuration : DbMigrationsConfiguration<WebApiTypeScriptContext>
	{
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = false;
			this.AutomaticMigrationDataLossAllowed = false;
		}

		protected override void Seed(WebApiTypeScriptContext context)
		{
			var buildConfiguration = context.GetBuildConfiguration();
			// Do not execute seeding for functional test 
			if (buildConfiguration == BuildConfiguration.FunctionalTest ||
				buildConfiguration == BuildConfiguration.Release ||
				buildConfiguration == BuildConfiguration.Review ||
				buildConfiguration == BuildConfiguration.LoadTest)
			{
				return;
			}

			base.Seed(context);

			this.ExecuteCleanupSql(context);
			this.ExecuteBuildConfigurationSql(context, buildConfiguration);
		}

		private void ExecuteCleanupSql(WebApiTypeScriptContext context)
		{
			var sql = this.GetType().Assembly.GetManifestResourceText(DbConstants.WEB_API_TYPESCRIPT_CONTEXT_CLEANUP_RESOURCE);
			context.Database.ExecuteSqlCommand(sql);
		}

		private void ExecuteBuildConfigurationSql(WebApiTypeScriptContext context, BuildConfiguration buildConfiguration)
		{
			string sql = "";
			if (buildConfiguration == BuildConfiguration.Debug)
			{
				sql = this.GetType().Assembly.GetManifestResourceText(DbConstants.WEB_API_TYPESCRIPT_CONTEXT_SEED_DEBUG_RESOURCE);
			}
			else
			{
				throw new DbUpdateException($"An error occured while seeding the database:\tCannot identify build configuration for connection string '{context.Database.Connection.ConnectionString}'.");
			}

			if (!string.IsNullOrWhiteSpace(sql))
			{
				context.Database.ExecuteSqlCommand(sql);
			}
		}
	}
}
