using Autofac;
using Serilog.Core;
using Serilog.Events;
using System.Web;
using WebApiTypeScript.Core.Constants;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Core.Services.Logging.Serilog
{
	public class RequestIdEnricher: ILogEventEnricher
	{
		public const string RequestIdProperty = LogConfigurationNames.REQUEST_ID_PARAMETER;
		private LogEventProperty cachedRequestId;

		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{

			this.cachedRequestId = propertyFactory.CreateProperty(RequestIdProperty, this.GetRequestId());
			logEvent.AddOrUpdateProperty(cachedRequestId);
		}

		private string GetRequestId()
		{
			var contextService = AppContainer.Current.Resolve<IContextService>();
			var result = contextService.RequestId ?? string.Empty;
			return result;
		}
	}
}
