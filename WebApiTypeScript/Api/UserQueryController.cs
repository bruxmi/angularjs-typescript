using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Api
{
	public class UserQueryController: ApiController
    {

		public UserQueryController(IUserQueryService queryService)
		{

		}
        public IHttpActionResult GetUsers()
        {
			var users = new List<User>();

			for (int i = 0; i < 10; i++)
			{
				users.Add(new User { firstName = "Max " + (i + 1), lastName = "Mustermann " + (i + 1), id = (i + 1)  });
			}
            return Ok(users);
        }


        public IHttpActionResult GetUser(int id)
        {
            var users = new List<User> { new User { firstName = "Sarah", lastName = "Musterfrau", id = 2 } };
            var result = users.FirstOrDefault(a => a.id == id);
            return Ok(result);
        }
    }

    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}