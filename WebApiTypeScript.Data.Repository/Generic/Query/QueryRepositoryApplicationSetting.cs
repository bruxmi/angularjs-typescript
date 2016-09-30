using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Data.Repository.Generic.Query
{
	public class QuerySettingsRepositoryApplicationSettingsSetting<T> : QueryRepositoryBase<T>, IQueryApplicationSettingsRepository<T>
		where T : class, IEntity
	{
		public QuerySettingsRepositoryApplicationSettingsSetting(IRepositoryApplicationSettingInitializer<T> initializer)
			: base(initializer)
		{
		}
	}
}
