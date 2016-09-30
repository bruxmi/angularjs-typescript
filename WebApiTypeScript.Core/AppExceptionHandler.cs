using WebApiTypeScript.Core.Interfaces.Services;
using WebApiTypeScript.Core.Services;

namespace WebApiTypeScript.Core
{
	public static class AppExceptionHandler
    {
        /// <summary>
        ///     Get the current exception handler.
        /// </summary>
        public static IExceptionHandlerService Current
            => Factory ?? (Factory = Create());

        /// <summary>
        /// Gets or sets the factory.
        /// </summary>
        public static IExceptionHandlerService Factory { private get; set; }

        public static IExceptionHandlerService Create()
        {
            return new ExceptionHandlerService(AppLogger.Current);
        }
    }
}
