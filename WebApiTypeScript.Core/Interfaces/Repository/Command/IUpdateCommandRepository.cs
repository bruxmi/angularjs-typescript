namespace KPMG.DE.Traction.Core.Interfaces.Repositories.Command
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUpdateCommandRepository<T>
        where T : class
    {
        Task UpdateAsync(T entity);

        Task UpdateListAsync(List<T> entities);
    }
}