using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Services.Query;
using WebApiTypeScript.Data.Repository.Generic;

namespace WebApiTypeScript.Data.Repository.Generic
{
	public class QueryRepository<T>: QueryRepositoryBase<T>
		where T : class, IEntity
	{

		//Hier sitzt das Problem
		public QueryRepository(IRepositoryInitializer<T> initializer) :
			base(initializer)
		{

		}
	}
}
