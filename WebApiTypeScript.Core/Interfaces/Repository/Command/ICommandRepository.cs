using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces.Repository.Command
{
	public interface ICommandRepository<T> : IUpdateCommandRepository<T>, IAddCommandRepository<T>, IDeleteCommandRepository<T>
		where T : class, IEntity
	{
	}
}
