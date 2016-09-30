using System;
using log4net;

namespace WebApiTypeScript.Core.Services.Logging
{
	public class Log4NetAdapter : Interfaces.ILog
    {
        private readonly ILog log4Net;

        public Log4NetAdapter(ILog log4Net)
        {
            this.log4Net = log4Net;
        }

        public virtual void Debug(string message)
        {
            this.log4Net.Debug(message);
        }

        public virtual void Error(string message, Exception e)
        {
            this.log4Net.Error(message, e);
        }

        public virtual void Fatal(string message, Exception e)
        {
            this.log4Net.Fatal(message, e);
        }

        public virtual void Info(string message)
        {
            this.log4Net.Info(message);
        }

        public virtual void Warn(string message)
        {
            this.log4Net.Warn(message);
        }
    }
}