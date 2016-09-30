using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities.Application;

namespace WebApiTypeScript.Core.Interfaces.Services.Query
{
	public interface IConnectionStringQueryService
	{
		Task<List<ConnectionString>> GetAllConnectionStringsAsync();
	}
}
