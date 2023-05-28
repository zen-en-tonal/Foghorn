using System;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public static class FoghornLoggerCriticalExtension
    {
        const LogLevel Level = LogLevel.Critical;

        public static void Critical(
            this FoghornLogger logger,
            string message,
            Exception ex
        )
        {
            logger.Log(Level, message, ex, LogAttributes.Empty);
        }

        public static void Critical(
            this FoghornLogger logger,
            string message,
            Exception ex,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, ex, attr);
        }

        public static void Critical(
            this FoghornLogger logger,
            string message
        )
        {
            logger.Log(Level, message, LogAttributes.Empty);
        }

        public static void Critical(
            this FoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, attr);
        }
    }
}
