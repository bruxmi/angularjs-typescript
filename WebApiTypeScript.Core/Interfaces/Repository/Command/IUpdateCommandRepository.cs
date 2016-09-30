using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces.Repository.Command
{
	public interface IUpdateCommandRepository<T>
        where T : class
    {
        Task UpdateAsync(T entity);

        Task UpdateListAsync(List<T> entities);
    }
}