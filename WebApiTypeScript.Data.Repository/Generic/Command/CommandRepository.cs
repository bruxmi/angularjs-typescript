using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.Repository.Generic.Command;

namespace WebApiTypeScript.Data.Repository.Generic.Command
{
	public class CommandRepository<T> : EfCommandRepositoryBase<T>
        where T : class, IEntity
    {
        public CommandRepository(WebApiTypeScriptContext context)
            : base(context)
        {
        }
    }
}