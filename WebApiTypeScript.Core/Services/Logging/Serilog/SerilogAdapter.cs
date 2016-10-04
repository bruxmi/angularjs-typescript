using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Services.Logging.Serilog
{
	public class SerilogAdapter : Interfaces.ILog
	{
        private readonly ILogger serlig;

		public SerilogAdapter(ILogger serilog)
		{
			this.serlig = serilog;
		}

		public virtual void Debug(string message)
		{
			this.serlig.Debug(message);
		}

		public virtual void Error(string message, Exception e)
		{
			this.serlig.Error(e, message);
		}

		public virtual void Fatal(string message, Exception e)
		{
			this.serlig.Error(e, message);
		}

		public virtual void Info(string message)
		{
			this.serlig.Information(message);
		}

		public virtual void Warn(string message)
		{
			this.serlig.Warning(message);
		}
	}
}
