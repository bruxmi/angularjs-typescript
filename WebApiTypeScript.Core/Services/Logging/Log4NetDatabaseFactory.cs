using System;
using System.Data;
using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using WebApiTypeScript.Core.Constants;
using ILog = WebApiTypeScript.Core.Interfaces.ILog;

namespace WebApiTypeScript.Core.Services.Logging
{
	public static class Log4NetDatabaseFactory
    {
        public static log4net.ILog Create()
        {
            var log = LogManager.GetLogger(Environment.MachineName);
            Configure();
            return log;
        }

        private static void AddDateTimeParameterToAppender(AdoNetAppender appender, string paramName)
        {
            var param = new AdoNetAppenderParameter
            {
                ParameterName = paramName,
                DbType = DbType.DateTime,
                Layout = new RawUtcTimeStampLayout()
            };
            appender.AddParameter(param);
        }

        private static void AddErrorParameterToAppender(AdoNetAppender appender, string paramName, int size)
        {
            var param = new AdoNetAppenderParameter
            {
                ParameterName = paramName,
                DbType = DbType.String,
                Size = size,
                Layout = new Layout2RawLayoutAdapter(new ExceptionLayout())
            };
            appender.AddParameter(param);
        }

        private static void AddStringParameterToAppender(AdoNetAppender appender, string paramName, int size, string conversionPattern)
        {
            var param = new AdoNetAppenderParameter
            {
                ParameterName = paramName,
                DbType = DbType.String,
                Size = size,
                Layout = new Layout2RawLayoutAdapter(new PatternLayout(conversionPattern))
            };
            appender.AddParameter(param);
        }

        private static void Configure()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();
            if (hierarchy.Configured)
            {
                return;
            }

            var database = new AdoNetAppender
            {
                Name = "AdoNetAppender",
                BufferSize = AppConfiguration.Current.LogDatabaseBufferSize,
                ConnectionType = AppConfiguration.Current.LogDatabaseConnectionType,
                ConnectionString = AppConfiguration.Current.ApplicationConnectionString,
                CommandText =
                    @"INSERT INTO Log ([Date],[Thread],[RequestId],[TenantName],[Level],[Logger],[Message],[Exception]) VALUES (@logdate, @thread, @requestId, @tenantName, @level, @logger, @message, @exception)",
                CommandType = CommandType.Text,
                UseTransactions = false
            };

            AddDateTimeParameterToAppender(database, "@logdate");
            AddStringParameterToAppender(database, "@thread", 255, "%thread");
            AddStringParameterToAppender(database, "@level", 50, "%level");
            AddStringParameterToAppender(database, "@logger", 255, "%logger");
            AddStringParameterToAppender(database, "@message", 4000, "%message");
            AddErrorParameterToAppender(database, "@exception", 2000);
            AddStringParameterToAppender(database, "@requestId", 50, $"%property{{{LogConfigurationNames.REQUEST_ID_PARAMETER}}}");
            AddStringParameterToAppender(database, "@tenantName", 255, $"%property{{{LogConfigurationNames.TENANT_NAME_PARAMETER}}}");
            database.ActivateOptions();

            hierarchy.Root.Level = Log4NetLevel.Parse(AppConfiguration.Current.LogLevel);
            hierarchy.Root.AddAppender(database);

            hierarchy.Configured = true;
        }
    }
}