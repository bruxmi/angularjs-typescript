using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Data.Repository.Generic;

namespace WebApiTypeScript.Data.Repository.Generic
{
	public class QueryRepository<T>: QueryRepositoryBase<T>
		where T : class, IEntity
	{

		//Hier sitzt das Problem
		public QueryRepository(RepositoryAppInitializer<T> initializer) :
			base(initializer)
		{

		}
	}
}
