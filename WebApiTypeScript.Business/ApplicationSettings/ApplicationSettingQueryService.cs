using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities.Application;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Business.ApplicationSettings
{
	public class ApplicationSettingQueryService : IApplicationSettingQueryService
	{
		private readonly IQueryApplicationSettingsRepository<ApplicationSetting> settingsRepository;

		public ApplicationSettingQueryService(IQueryApplicationSettingsRepository<ApplicationSetting> settingsRepository)
		{
			this.settingsRepository = settingsRepository;
		}

		public async Task<List<ApplicationSetting>> GetAllApplicationSettingsAsync()
		{
			return await this.settingsRepository.GetAllAsync();
		}
	}
}
