using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public static class FoghornLoggerDebugExtension
    {
        const LogLevel Level = LogLevel.Debug;

        public static void Debug(
            this IFoghornLogger logger,
            string message
        )
        {
            logger.Log(Level, message, null, LogAttributes.Empty);
        }

        public static void Debug(
            this IFoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, null, attr);
        }

        public static Task DebugAsync(
            this IFoghornLogger logger,
            string message
        )
        {
            return logger.LogAsync(Level, message, null, LogAttributes.Empty);
        }

        public static Task DebugAsync(
            this IFoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            return logger.LogAsync(Level, message, null, attr);
        }
    }
}
