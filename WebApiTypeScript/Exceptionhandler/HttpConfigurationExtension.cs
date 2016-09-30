using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApiTypeScript.Core.Interfaces.Services;

namespace WebApiTypeScript.Exceptionhandler
{
	public static class HttpConfigurationExtensions
    {
        public static HttpConfiguration ConfigureExceptionHandling(this HttpConfiguration httpConfiguration, IExceptionHandlerService exceptionHandlerService)
        {
            httpConfiguration.Services.Add(typeof(IExceptionLogger), new AppExceptionLogger(exceptionHandlerService));

            return httpConfiguration;
        }
    }
}