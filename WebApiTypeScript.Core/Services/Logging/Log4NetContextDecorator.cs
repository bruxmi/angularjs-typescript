using System;
using System.Web;
using Autofac.Core;
using log4net;
using WebApiTypeScript.Core.Constants;

namespace WebApiTypeScript.Core.Services.Logging
{
	public sealed class Log4NetContextDecorator : Interfaces.ILog
    {
        private readonly Interfaces.ILog log;

        public Log4NetContextDecorator(Interfaces.ILog log)
        {
            this.log = log;
        }

        public void Debug(string message)
        {
            this.Decorate();
            this.log.Debug(message);
        }

        public void Error(string message, Exception e)
        {
            this.Decorate();
            this.log.Error(message, e);
        }

        public void Fatal(string message, Exception e)
        {
            this.Decorate();
            this.log.Fatal(message, e);
        }

        public void Info(string message)
        {
            this.Decorate();
            this.log.Info(message);
        }

        public void Warn(string message)
        {
            this.Decorate();
            this.log.Warn(message);
        }

        private void Decorate()
        {
            try
            {
                // Since IContextService is registered PerRequestLifetimeManager, 
                // it can only be used in the context of an HTTP request
                if (HttpContext.Current != null)
                {
                    LogicalThreadContext.Properties[LogConfigurationNames.REQUEST_ID_PARAMETER] = HttpContext.Current.Items[HttpContextItems.REQUEST_ID] ?? string.Empty;
                    LogicalThreadContext.Properties[LogConfigurationNames.TENANT_NAME_PARAMETER] = HttpContext.Current.Items[HttpContextItems.TENANT_NAME] ?? string.Empty;
                }
                else
                {
                    LogicalThreadContext.Properties[LogConfigurationNames.REQUEST_ID_PARAMETER] = string.Empty;
                    LogicalThreadContext.Properties[LogConfigurationNames.TENANT_NAME_PARAMETER] = string.Empty;
                }
            }
            catch (DependencyResolutionException)
            {
                /* do nothing */
            }
        }
    }
}