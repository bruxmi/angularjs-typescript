using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;
using WebApiTypeScript.Core;
using WebApiTypeScript.Core.Interfaces.Services;
using WebApiTypeScript.Exceptionhandler;

namespace WebApiTypeScript
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services
			config.ConfigureExceptionHandling(AppContainer.Current.Resolve<IExceptionHandlerService>());

			// Web API routes
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
