using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities;

namespace WebApiTypeScript.Core.Interfaces.Services.Query
{
	public interface IUserQueryService
	{
		Task<List<User>> GetAllUserAsync();

		Task<User> GetUserByIdAsync(int id);
	}
}
