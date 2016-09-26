using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Business
{
	public class UserQueryService : IUserQueryService
	{
		private readonly IQueryRepository<User> userQueryRepository;
		public UserQueryService(IQueryRepository<User> userQueryRepository)
		{
			this.userQueryRepository = userQueryRepository;
		}

		public async Task<List<User>> GetAllUserAsync()
		{
			var users = new List<User>();

			for (int i = 0; i < 10; i++)
			{
				users.Add(new User { FirstName = "Max " + (i + 1), LastName = "Mustermann " + (i + 1), Id = (i + 1) });
			}
			return await Task.FromResult(users);
		}

		public async Task<User> GetUserByIdAsync(int id)
		{
			var users = new List<User> { new User { FirstName = "Sarah", LastName = "Musterfrau", Id = 1 } };
			var result = users.FirstOrDefault(a => a.Id == id);
			return await Task.FromResult(result);
		}
	}
}
