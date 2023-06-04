using Foghorn.Log;

namespace Foghorn.Logging
{
    public class LogLevelFilter : IFoghornLoggerFilter
    {
        private LogLevel MinLogLevel;

        public LogLevelFilter(LogLevel logLevel)
        {
            this.MinLogLevel = logLevel;
        }

        public bool IsEnabledOn(FoghornLog log)
        {
            return this.MinLogLevel <= log.LogLevel;
        }
    }
}
