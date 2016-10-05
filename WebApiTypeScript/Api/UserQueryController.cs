using System.Threading.Tasks;
using System.Web.Http;
using WebApiTypeScript.Api.Base;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Api
{
	public class UserQueryController: BaseApiController<IUserQueryService>
	{
		public async Task<IHttpActionResult> GetUsers()
        {
			var users = await this.Service.GetAllUserAsync();
			return Ok(users);
        }


        public async Task<IHttpActionResult> GetUser(int id)
        {
			var user = await this.Service.GetUserByIdAsync(id);
			return Ok(user);
		}
    }
}