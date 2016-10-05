using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces.Services.Query
{
	public interface IContextService
	{
		string RequestId { get; set; }
	}
}
