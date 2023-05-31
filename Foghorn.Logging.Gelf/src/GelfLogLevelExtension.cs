using System.Collections.Generic;
using Foghorn.Log;

namespace Foghorn.Logging.Gelf
{
    public static class GelfLogLevelExtension
    {
        static Dictionary<LogLevel, GelfLogLevel> GelfLogLevelMap =
            new Dictionary<LogLevel, GelfLogLevel>()
            {
                [LogLevel.Critical] = GelfLogLevel.Critical,
                [LogLevel.Error] = GelfLogLevel.Error,
                [LogLevel.Warning] = GelfLogLevel.Warning,
                [LogLevel.Information] = GelfLogLevel.Informational,
                [LogLevel.Debug] = GelfLogLevel.Debug,
                [LogLevel.Trace] = GelfLogLevel.Debug
            };

        /// <summary>
        /// Converts the Fogforn.Log.LogLevel into the GelfLogLevel.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static GelfLogLevel ToGelfLogLevel(this LogLevel self)
        {
            return GelfLogLevelMap[self];
        }
    }
}
