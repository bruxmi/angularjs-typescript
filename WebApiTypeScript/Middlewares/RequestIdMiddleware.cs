using Autofac;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiTypeScript.Core;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Middlewares
{
	public class RequestIdMiddleware : OwinMiddleware
	{
		public RequestIdMiddleware(OwinMiddleware next)
			: base(next)
		{
		}

		public override async Task Invoke(IOwinContext context)
		{
			var contextService = AppContainer.Current.Resolve<IContextService>();
			contextService.RequestId = Guid.NewGuid().ToString();

			var middleware = this.GetType().Name;
			var log = AppContainer.Current.Resolve<ILog>();
			log.Debug($"Handling request '{context?.Request?.Method} {context?.Request?.Uri}'...");
			log.Debug($"Invoking middleware '{middleware}'...");

			await this.Next.Invoke(context);
		}
	}
}