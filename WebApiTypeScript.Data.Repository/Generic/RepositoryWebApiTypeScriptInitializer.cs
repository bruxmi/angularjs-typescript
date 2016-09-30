using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Data.AppContext;

namespace WebApiTypeScript.Data.Repository.Generic
{
	public class RepositoryWebApiTypeScriptInitializer<T> : RepositoryBaseInitializer<T>
		where T : class, IEntity
	{
		public RepositoryWebApiTypeScriptInitializer(WebApiTypeScriptContext context)
            : base(context)
        {

		}
	}
}
