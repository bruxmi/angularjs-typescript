using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces.Services.Query
{
	public interface IRepositoryInitializer<T>
			where T : class, IEntity
	{
		DbSet<T> GetDbSet();
	}
}
