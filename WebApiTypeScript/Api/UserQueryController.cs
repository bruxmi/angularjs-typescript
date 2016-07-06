using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiTypeScript.Api
{
    public class UserQueryController: ApiController
    {
        public IHttpActionResult GetUsers()
        {
            var users = new List<User> { new User { firstName = "Chris", lastName = "van Boxmer", id = 1 } };
            return Ok(users);
        }

        public IHttpActionResult GetUser(int id)
        {
            var users = new List<User> { new User { firstName = "Chris", lastName = "van Boxmer", id = 1 } };
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