using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces
{
	public interface ILog
	{
		void Debug(string message);

		void Error(string message, Exception e);

		void Fatal(string message, Exception e);

		void Info(string message);

		void Warn(string message);
	}
}
