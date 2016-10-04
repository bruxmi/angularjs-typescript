using Serilog.Core;
using Serilog.Events;
using System.Web;
using WebApiTypeScript.Core.Constants;

namespace WebApiTypeScript.Core.Services.Logging.Serilog
{
	public class RequestIdEnricher: ILogEventEnricher
	{
		public const string RequestIdProperty = LogConfigurationNames.REQUEST_ID_PARAMETER;
		private LogEventProperty cachedRequestId;

		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			this.cachedRequestId = this.cachedRequestId ?? propertyFactory.CreateProperty(RequestIdProperty, this.GetRequestId());
			logEvent.AddPropertyIfAbsent(cachedRequestId);
		}

		private string GetRequestId()
		{
			if (HttpContext.Current != null)
			{
				var result =  (string)HttpContext.Current.Items[HttpContextItems.REQUEST_ID] ?? string.Empty;
				return result;
			}
			return string.Empty;
		}
	}
}
