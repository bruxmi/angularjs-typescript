using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Constants
{
	public static class LogConfigurationNames
	{
		// Default Values
		public const string DEFAULT_LOG_FILE_PATH = @"c:\dev\Traction_Logfiles";

		public const string DEFAULT_LOG_FILE_NAME = "Application.log";

		public const string DEFAULT_LOG_CONVERSION_PATTERN = "%date [%thread] %-5level %logger - %message%newline";

		public const string DEFAULT_LOG_MAX_FILE_SIZE = "50MB";

		public const string DEFAULT_LOG_LEVEL = "Error";

		// Keys
		public const string KEY_LOG_FILE_PATH = "LogFilePath";

		public const string KEY_LOG_FILE_NAME = "LogFileName";

		public const string KEY_LOG_CONVERSION_PATTERN = "LogConversionPattern";

		public const string KEY_LOG_MAX_FILE_SIZE = "LogMaxFileSize";

		public const string KEY_LOG_LEVEL = "LogLevel";

		public const string KEY_LOG_INSTRUMENTATION_KEY = "LogInstrumentationKey";

		public const string KEY_LOG_MODE = "LogMode";

		public const string KEY_LOG_DATABASE_CONNECTION_TYPE = "LogDatabaseConnectionType";

		public const string KEY_LOG_DATABASE_BUFFER_SIZE = "LogDatabaseBufferSize";

		// Additional Parameters
		public const string REQUEST_ID_PARAMETER = "RequestId";

		public const string TENANT_NAME_PARAMETER = "TenantName";
	}
}
