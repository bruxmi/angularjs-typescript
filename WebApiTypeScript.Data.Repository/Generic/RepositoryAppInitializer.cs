using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Data.AppContext;
namespace WebApiTypeScript.Data.Repository.Generic
{
	public class RepositoryAppInitializer<T> : RepositoryBaseInitializer<T>
		where T : class, IEntity
	{
		public RepositoryAppInitializer(WebApiTypeScriptContext context)
            : base(context)
        {

		}
	}
}
