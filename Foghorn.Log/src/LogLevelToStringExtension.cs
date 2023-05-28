using System.Collections.Generic;

namespace Foghorn.Log
{
    public static class LogLevelToStringExtension
    {
        static readonly Dictionary<LogLevel, string> Dict =
            new Dictionary<LogLevel, string>()
            {
                [LogLevel.Trace] = "Trace",
                [LogLevel.Debug] = "Debug",
                [LogLevel.Information] = "Info",
                [LogLevel.Warning] = "Warning",
                [LogLevel.Error] = "Error",
                [LogLevel.Critical] = "Critical",
            };

        public static string AsReadable(this LogLevel self)
        {
            return Dict[self];
        }
    }
}