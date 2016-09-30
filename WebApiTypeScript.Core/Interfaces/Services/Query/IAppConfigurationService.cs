using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Enums;

namespace WebApiTypeScript.Core.Interfaces.Services.Query
{
	public interface IAppConfigurationService
	{
		/// <summary>
		///     Gets the log database buffer size.
		/// </summary>
		int LogDatabaseBufferSize { get; }

		/// <summary>
		///     Gets the log database connection type.
		/// </summary>
		string LogDatabaseConnectionType { get; }

		/// <summary>
		///     Gets the name of the log file.
		/// </summary>
		string LogFileName { get; }

		/// <summary>
		///     Gets the log file path.
		/// </summary>
		string LogFilePath { get; }

		/// <summary>
		///     Gets the log file instrumentation key.
		/// </summary>
		string LogInstrumentationKey { get; }

		/// <summary>
		///     Gets the log level.
		/// </summary>
		string LogLevel { get; }

		/// <summary>
		///     Gets the size of the log file maximum file.
		/// </summary>
		string LogMaxFileSize { get; }

		/// <summary>
		/// Gets the log mode.
		/// </summary>
		LogMode LogMode { get; }

		string ApplicationConnectionString { get; }
	}
}
