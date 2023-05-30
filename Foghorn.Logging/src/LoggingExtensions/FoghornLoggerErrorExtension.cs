using System;
using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public static class FoghornLoggerErrorExtension
    {
        const LogLevel Level = LogLevel.Error;

        public static void Error(
            this IFoghornLogger logger,
            string message,
            Exception ex
        )
        {
            logger.Log(Level, message, ex, LogAttributes.Empty);
        }

        public static void Error(
            this IFoghornLogger logger,
            string message,
            Exception ex,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, ex, attr);
        }

        public static void Error(
            this IFoghornLogger logger,
            string message
        )
        {
            logger.Log(Level, message, null, LogAttributes.Empty);
        }

        public static void Error(
            this IFoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, null, attr);
        }

        public static Task ErrorAsync(
            this IFoghornLogger logger,
            string message,
            Exception ex
        )
        {
            return logger.LogAsync(Level, message, ex, LogAttributes.Empty);
        }

        public static Task ErrorAsync(
            this IFoghornLogger logger,
            string message,
            Exception ex,
            LogAttributes attr
        )
        {
            return logger.LogAsync(Level, message, ex, attr);
        }

        public static Task ErrorAsync(
            this IFoghornLogger logger,
            string message
        )
        {
            return logger.LogAsync(Level, message, null, LogAttributes.Empty);
        }

        public static Task ErrorAsync(
            this IFoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            return logger.LogAsync(Level, message, null, attr);
        }
    }
}
