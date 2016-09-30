using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace WebApiTypeScript.Core.Extensions
{
    #region

	

	#endregion

    /// <summary>
    ///     Encapsulates extension methods for the <see cref="Exception" />.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        ///     Flattens the exception messages including the inner exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>Returns the flattened exception message.</returns>
        public static string FlattenedMessage(this Exception exception)
        {
            if (exception == null)
            {
                return string.Empty;
            }

            var result = string.Empty;

            var messages = new HashSet<string>();
            while (exception != null)
            {
                // Avoid duplicate messages
                if (!messages.Contains(exception.Message))
                {
                    messages.Add(exception.Message);
                    result += Environment.NewLine + exception.Message;
                }

                exception = exception.InnerException;
            }

            return result;
        }

        /// <summary>
        /// Rethrows the specified exception without losing the stack trace.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void Rethrow(this Exception exception)
        {
            if (exception != null)
            {
                ExceptionDispatchInfo.Capture(exception).Throw();
            }
        }
    }
}