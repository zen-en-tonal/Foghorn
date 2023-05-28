using Foghorn.Log;

namespace Foghorn.Logging
{
    public static class FoghornLoggerWarningExtension
    {
        const LogLevel Level = LogLevel.Warning;

        public static void Warning(
            this FoghornLogger logger,
            string message
        )
        {
            logger.Log(Level, message, LogAttributes.Empty);
        }

        public static void Warning(
            this FoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, attr);
        }
    }
}
