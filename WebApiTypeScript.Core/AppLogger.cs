using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Services.Logging;

namespace WebApiTypeScript.Core
{
	public static class AppLogger
    {
        /// <summary>
        ///     Gets the current instance of the logger.
        /// </summary>
        public static ILog Current
            => Factory ?? (Factory = Create());

        /// <summary>
        ///     Gets or sets the factory.
        /// </summary>
        public static ILog Factory { private get; set; }

        /// <summary>
        ///     Creates a new instance of the logger,
        ///     but without affecting the current instance.
        /// </summary>
        /// <returns>Returns an instance of type <see cref="ILog" />.</returns>
        public static ILog Create()
        {
            var log4Net = Log4NetDatabaseFactory.Create();
            var log = new Log4NetAdapter(log4Net);
            var decoratedLog = new Log4NetContextDecorator(log);

            return decoratedLog;
        }
    }
}