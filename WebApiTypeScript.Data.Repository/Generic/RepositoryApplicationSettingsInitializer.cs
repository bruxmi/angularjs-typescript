using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.ApplicationSettingsContext;
using WebApiTypeScript.Data.Repository.Generic.Query;

namespace WebApiTypeScript.Data.Repository.Generic
{
	public class RepositoryApplicationSettingsInitializer<T> : RepositoryBaseInitializer<T>, IRepositoryApplicationSettingInitializer<T>
		where T : class, IEntity
	{
		public RepositoryApplicationSettingsInitializer(AppSettingContext context)
            : base(context)
        {

		}
	}
}
