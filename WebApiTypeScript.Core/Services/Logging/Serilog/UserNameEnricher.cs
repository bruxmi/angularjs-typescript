using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;
using System.Security.Principal;

namespace WebApiTypeScript.Core.Services.Logging.Serilog
{
	public class UserNameEnricher: ILogEventEnricher
	{
		public  const string UserNameProperty = "UserName";
		private LogEventProperty cachedUserName;
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			this.cachedUserName = this.cachedUserName ?? propertyFactory.CreateProperty(UserNameProperty, this.GetUserName());
			logEvent.AddPropertyIfAbsent(cachedUserName);
		}

		private string GetUserName()
		{
			return WindowsIdentity.GetCurrent().Name;
		}
	}
}
