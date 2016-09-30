using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Constants
{
	public static class DbConstants
	{
		public const string APPLICATION_CONTEXT_CLEANUP_RESOURCE =
			"WebApiTypeScript.Data.ApplicationSettingsContext.SQL.Data.Cleanup.sql";

		public const string APPLICATION_CONTEXT_SEED_DEBUG_RESOURCE =
			"WebApiTypeScript.Data.ApplicationSettingsContext.SQL.Data.Debug.SeedBuildConfiguration.sql";

		public const string APPLICATION_CONTEXT_SEED_RESOURCE =
			"WebApiTypeScript.Data.ApplicationSettingsContext.SQL.Data.Seed.sql";

		public const string DEBUG_IDENTIFIER =
			@"Debug";

		public const string WEB_API_TYPESCRIPT_CONTEXT_CLEANUP_RESOURCE =
		"WebApiTypeScript.Data.AppContext.SQL.Data.Cleanup.sql";

		public const string WEB_API_TYPESCRIPT_CONTEXT_SEED_DEBUG_RESOURCE =
		"WebApiTypeScript.Data.AppContext.SQL.Data.Debug.SeedBuildConfiguration.sql";

		public const string WEB_API_TYPESCRIPT_CONTEXT_PROJECT_NAME =
		"WebApiTypeScript.Data.AppContext";
	}
}
