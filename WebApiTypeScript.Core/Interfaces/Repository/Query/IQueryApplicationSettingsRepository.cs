using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces.Repository.Query
{
	public interface IQueryApplicationSettingsRepository<T> : IQueryRepository<T>
		where T : class, IEntity
	{
	}
}
