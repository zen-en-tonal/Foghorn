using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public static class FoghornLoggerInfoExtension
    {
        const LogLevel Level = LogLevel.Information;

        public static void Info(
            this IFoghornLogger logger,
            string message
        )
        {
            logger.Log(Level, message, null, LogAttributes.Empty);
        }

        public static void Info(
            this IFoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, null, attr);
        }

        public static Task InfoAsync(
            this IFoghornLogger logger,
            string message
        )
        {
            return logger.LogAsync(Level, message, null, LogAttributes.Empty);
        }

        public static Task InfoAsync(
            this IFoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            return logger.LogAsync(Level, message, null, attr);
        }
    }
}
