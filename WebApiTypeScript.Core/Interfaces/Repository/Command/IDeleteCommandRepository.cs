namespace KPMG.DE.Traction.Core.Interfaces.Repositories.Command
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDeleteCommandRepository<T>
        where T : class
    {
        Task DeleteAsync(T entity);

        Task DeleteListAsync(ICollection<T> entityList);

    }
}