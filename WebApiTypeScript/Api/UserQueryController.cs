using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiTypeScript.Core;
using WebApiTypeScript.Core.Entities;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Api
{
	public class UserQueryController: ApiController
	{
		public UserQueryController()
		{
			//ist nur als test zu checken wieso er das ding nicht erzeugen kann 
			var b = AppContainer.Current.Resolve<IQueryRepository<User>>();
		}
		public async Task<IHttpActionResult> GetUsers()
        {
			//var users = await this.Service.GetAllUserAsync();
			return Ok();
        }


        public async Task<IHttpActionResult> GetUser(int id)
        {
			//var user = await this.Service.GetUserByIdAsync(id);
			//return Ok(user);
			return Ok();
		}
    }
}