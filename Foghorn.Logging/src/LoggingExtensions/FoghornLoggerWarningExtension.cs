using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public static class FoghornLoggerWarningExtension
    {
        const LogLevel Level = LogLevel.Warning;

        public static void Warning(
            this IFoghornLogger logger,
            string message
        )
        {
            logger.Log(Level, message, null, LogAttributes.Empty);
        }

        public static void Warning(
            this IFoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, null, attr);
        }

        public static Task WarningAsync(
            this IFoghornLogger logger,
            string message
        )
        {
            return logger.LogAsync(Level, message, null, LogAttributes.Empty);
        }

        public static Task WarningAsync(
            this IFoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            return logger.LogAsync(Level, message, null, attr);
        }
    }
}
