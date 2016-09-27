using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Data.Repository.Generic.Query
{
	public class QueryRepository<T> : QueryRepositoryBase<T>
		where T : class, IEntity
	{
		public QueryRepository(IRepositoryInitializer<T> initializer) :
			base(initializer)
		{
		}
	}
}