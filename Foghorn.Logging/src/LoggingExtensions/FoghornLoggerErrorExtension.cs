using System;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public static class FoghornLoggerErrorExtension
    {
        const LogLevel Level = LogLevel.Error;

        public static void Error(
            this FoghornLogger logger,
            string message,
            Exception ex
        )
        {
            logger.Log(Level, message, ex, LogAttributes.Empty);
        }

        public static void Error(
            this FoghornLogger logger,
            string message,
            Exception ex,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, ex, attr);
        }

        public static void Error(
            this FoghornLogger logger,
            string message
        )
        {
            logger.Log(Level, message, LogAttributes.Empty);
        }

        public static void Error(
            this FoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, attr);
        }
    }
}
