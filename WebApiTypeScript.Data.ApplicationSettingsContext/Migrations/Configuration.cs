using System.Data.Entity.Infrastructure;
using WebApiTypeScript.Core.Constants;
using WebApiTypeScript.Core.Enums;
using WebApiTypeScript.Core.Extensions;

namespace WebApiTypeScript.Data.ApplicationSettingsContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiTypeScript.Data.ApplicationSettingsContext.AppSettingContext>
    {
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = false;
			this.AutomaticMigrationDataLossAllowed = false;
		}

		protected override void Seed(AppSettingContext context)
		{
			var buildConfiguration = context.GetBuildConfiguration();
			if (buildConfiguration == BuildConfiguration.Release || buildConfiguration == BuildConfiguration.Review || buildConfiguration == BuildConfiguration.FunctionalTest || buildConfiguration == BuildConfiguration.LoadTest)
			{
				return;
			}

			base.Seed(context);

			this.ExecuteCleanupSql(context);
			this.ExecuteSeedSql(context);
			this.ExecuteBuildConfigurationSql(context, buildConfiguration);
		}

		private void ExecuteCleanupSql(AppSettingContext context)
		{
			var sql = this.GetType().Assembly.GetManifestResourceText(DbConstants.APPLICATION_CONTEXT_CLEANUP_RESOURCE);
			context.Database.ExecuteSqlCommand(sql);
		}

		private void ExecuteSeedSql(AppSettingContext context)
		{
			var sql = this.GetType().Assembly.GetManifestResourceText(DbConstants.APPLICATION_CONTEXT_SEED_RESOURCE);
			context.Database.ExecuteSqlCommand(sql);
		}

		private void ExecuteBuildConfigurationSql(AppSettingContext context, BuildConfiguration buildConfiguration)
		{
			string sql = null;
			if (buildConfiguration == BuildConfiguration.Debug)
			{
				sql = this.GetType().Assembly.GetManifestResourceText(DbConstants.APPLICATION_CONTEXT_SEED_DEBUG_RESOURCE);
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
