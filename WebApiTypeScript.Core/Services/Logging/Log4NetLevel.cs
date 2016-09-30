using log4net.Core;
using WebApiTypeScript.Core.Extensions;

namespace WebApiTypeScript.Core.Services.Logging
{
	public static class Log4NetLevel
    {
        public static Level Parse(string value)
        {
            if (value.EqualsIgnoreCase("all"))
            {
                return Level.All;
            }

            if (value.EqualsIgnoreCase("debug"))
            {
                return Level.Debug;
            }

            if (value.EqualsIgnoreCase("info"))
            {
                return Level.Info;
            }

            if (value.EqualsIgnoreCase("warn"))
            {
                return Level.Warn;
            }

            if (value.EqualsIgnoreCase("error"))
            {
                return Level.Error;
            }

            if (value.EqualsIgnoreCase("fatal"))
            {
                return Level.Fatal;
            }

            if (value.EqualsIgnoreCase("off"))
            {
                return Level.Off;
            }

            return Level.All;
        }
    }
}