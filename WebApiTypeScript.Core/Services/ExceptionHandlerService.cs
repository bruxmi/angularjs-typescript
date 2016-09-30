using System;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Exceptions;
using WebApiTypeScript.Core.Extensions;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Services;

namespace WebApiTypeScript.Core.Services
{
	public class ExceptionHandlerService : IExceptionHandlerService
    {
        private readonly ILog log;

        public ExceptionHandlerService(ILog log)
        {
            this.log = log;
        }

        public Task Handle(Exception exception)
        {
            var message = exception.FlattenedMessage();
            if (exception is BaseAppException)
            {
                this.log.Warn(message);
            }
            else
            {
                this.log.Error(message, exception);
            }

            return Task.FromResult(0);
        }
    }
}
