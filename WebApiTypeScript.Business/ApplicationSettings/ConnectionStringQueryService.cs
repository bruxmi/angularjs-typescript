using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities.Application;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Business.ApplicationSettings
{
	public class ConnectionStringQueryService: IConnectionStringQueryService
	{
		private readonly IQueryApplicationSettingsRepository<ConnectionString> connectionStringRepository;

		public ConnectionStringQueryService(IQueryApplicationSettingsRepository<ConnectionString> connectionStringRepository)
		{
			this.connectionStringRepository = connectionStringRepository;
		}

		public async Task<List<ConnectionString>> GetAllConnectionStringsAsync()
		{
			var result = await this.connectionStringRepository.GetAllAsync();
			return result;
		}
	}
}
