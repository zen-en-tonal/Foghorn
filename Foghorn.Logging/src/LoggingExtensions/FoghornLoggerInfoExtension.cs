using Foghorn.Log;

namespace Foghorn.Logging
{
    public static class FoghornLoggerInfoExtension
    {
        const LogLevel Level = LogLevel.Information;

        public static void Info(
            this FoghornLogger logger,
            string message
        )
        {
            logger.Log(Level, message, LogAttributes.Empty);
        }

        public static void Info(
            this FoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, attr);
        }
    }
}
