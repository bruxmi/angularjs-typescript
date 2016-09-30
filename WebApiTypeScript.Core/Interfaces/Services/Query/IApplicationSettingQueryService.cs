using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities.Application;

namespace WebApiTypeScript.Core.Interfaces.Services.Query
{
	public interface IApplicationSettingQueryService
	{
		/// <summary>
		/// Gets all application settings asynchronously.
		/// </summary>
		/// <returns>Returns a <see cref="Task"/> with a list of <see cref="ApplicationSetting"/></returns>
		Task<List<ApplicationSetting>> GetAllApplicationSettingsAsync();
	}
}
