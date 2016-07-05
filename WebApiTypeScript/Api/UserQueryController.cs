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
            var users = new List<User> { new User { firstName = "Chris", lastName = "van Boxmer" } };
            return Ok(users);
        }
    }

    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}