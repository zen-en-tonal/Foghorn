using Foghorn.Log;

namespace Foghorn.Logging
{
    public static class FoghornLoggerDebugExtension
    {
        const LogLevel Level = LogLevel.Debug;

        public static void Debug(
            this FoghornLogger logger,
            string message
        )
        {
            logger.Log(Level, message, LogAttributes.Empty);
        }

        public static void Debug(
            this FoghornLogger logger,
            string message,
            LogAttributes attr
        )
        {
            logger.Log(Level, message, attr);
        }
    }
}
