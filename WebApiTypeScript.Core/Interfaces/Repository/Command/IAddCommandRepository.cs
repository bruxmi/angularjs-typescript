namespace KPMG.DE.Traction.Core.Interfaces.Repositories.Command
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAddCommandRepository<T>
        where T : class
    {
        Task AddAsync(T entity);

        Task AddListAsync(ICollection<T> entityList);
    }
}
