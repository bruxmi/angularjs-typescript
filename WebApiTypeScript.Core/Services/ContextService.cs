using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApiTypeScript.Core.Constants;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Core.Services
{
	public class ContextService : IContextService
	{
		private string requestId;

		public string RequestId
		{
			get
			{
				return this.requestId ?? string.Empty;
			}
			set
			{
				this.requestId = value;

				if (HttpContext.Current != null)
				{
					HttpContext.Current.Items.Add(HttpContextItems.REQUEST_ID, this.requestId);
				}
			}
		}
	}
}
