using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Constants;
using WebApiTypeScript.Core.Entities.Application;
using WebApiTypeScript.Core.Enums;
using WebApiTypeScript.Core.Extensions;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Core.Services
{
	public class AppConfigurationService: IAppConfigurationService
	{
		private readonly IApplicationSettingQueryService applicationSettingQueryService;
		private readonly IConnectionStringQueryService connectionStringQueryService;
		private List<ApplicationSetting> applicationSettings;
		private List<ConnectionString> connectionStrings;

		public AppConfigurationService(IApplicationSettingQueryService applicationSettingQueryService, 
			IConnectionStringQueryService connectionStringQueryService)
		{
			this.applicationSettingQueryService = applicationSettingQueryService;
			this.connectionStringQueryService = connectionStringQueryService;
			this.InitializeAsync().Wait();
		}

		public virtual string GetApplicationSetting(string key)
		{
			return this.applicationSettings.SingleOrDefault(s => s.Key.EqualsIgnoreCase(key))?.Value;
		}

		public virtual string LogConversionPattern => this.GetApplicationSetting(LogConfigurationNames.KEY_LOG_CONVERSION_PATTERN);

		public int LogDatabaseBufferSize
		{
			get
			{
				var bufferSize = this.GetApplicationSetting(LogConfigurationNames.KEY_LOG_DATABASE_BUFFER_SIZE);
				return int.Parse(bufferSize, CultureInfo.InvariantCulture);
			}
		}

		public string LogDatabaseConnectionType => this.GetApplicationSetting(LogConfigurationNames.KEY_LOG_DATABASE_CONNECTION_TYPE);

		public virtual string LogFileName => this.GetApplicationSetting(LogConfigurationNames.KEY_LOG_FILE_NAME);

		public virtual string LogFilePath => this.GetApplicationSetting(LogConfigurationNames.KEY_LOG_FILE_PATH);

		public virtual string LogInstrumentationKey => this.GetApplicationSetting(LogConfigurationNames.KEY_LOG_INSTRUMENTATION_KEY);

		public virtual string LogLevel => this.GetApplicationSetting(LogConfigurationNames.KEY_LOG_LEVEL);

		public virtual string LogMaxFileSize => this.GetApplicationSetting(LogConfigurationNames.KEY_LOG_MAX_FILE_SIZE);

		public virtual string ApplicationConnectionString => this.GetConnectionString(DbCreationConfigurationNames.APPLICATION_SETTINGS_CONTEXT_NAME);

		public virtual LogMode LogMode
		{
			get
			{
				var logMode = this.GetApplicationSetting(LogConfigurationNames.KEY_LOG_MODE);

				if (string.IsNullOrWhiteSpace(logMode))
				{
					this.ThrowExceptionNoValueFound(LogConfigurationNames.KEY_LOG_MODE);
				}

				Debug.Assert(logMode != null, "logType != null");
				return (LogMode)Enum.Parse(typeof(LogMode), logMode.ToUpper()); // Handling typos gently by converting to uppercase
			}
		}
		public virtual string GetConnectionString(string name)
		{
			var result = this.connectionStrings.FirstOrDefault(s => s.Name.EqualsIgnoreCase(name));
			return result != null ? result.Value : string.Empty;
		}

		private void ThrowExceptionNoValueFound(string key)
		{
			this.ThrowException($"No value found for application settings key {key}.");
		}

		private void ThrowException(string message)
		{
			throw new ConfigurationErrorsException(message);
		}

		private async Task InitializeAsync()
		{
			this.applicationSettings = await this.applicationSettingQueryService.GetAllApplicationSettingsAsync();
			this.connectionStrings = await this.connectionStringQueryService.GetAllConnectionStringsAsync();
		}
	}
}
