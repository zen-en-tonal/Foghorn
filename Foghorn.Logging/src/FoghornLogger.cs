using System;
using System.Linq;
using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public class FoghornLogger
    {
        private readonly FoghornLoggerConfiguration Config;

        public FoghornLogger(FoghornLoggerConfiguration config)
        {
            this.Config = config;
        }

        public bool InEnabled(LogLevel logLevel)
        {
            return logLevel >= this.Config.MinLogLevel;
        }

        public void Log(
            LogLevel logLevel,
            string ident,
            string host,
            string message,
            LogAttributes attributes)
        {
            this.Log(new FoghornLog(
                ident, logLevel, message,
                host, DateTime.Now, attributes
            ));
        }

        public void Log(
            LogLevel logLevel,
            string ident,
            string host,
            string message,
            Exception e,
            LogAttributes attributes)
        {
            this.Log(new FoghornLog(
                ident, logLevel, message,
                host, DateTime.Now, this.AppendException(attributes, e)
            ));
        }

        public async Task LogAsync(
            LogLevel logLevel,
            string ident,
            string host,
            string message,
            LogAttributes attributes)
        {
            await this.LogAsync(new FoghornLog(
                ident, logLevel, message,
                host, DateTime.Now, attributes
            ));
        }

        public async Task LogAsync(
            LogLevel logLevel,
            string ident,
            string host,
            string message,
            Exception e,
            LogAttributes attributes)
        {
            await this.LogAsync(new FoghornLog(
                ident, logLevel, message,
                host, DateTime.Now, this.AppendException(attributes, e)
            ));
        }

        private void Log(FoghornLog log)
        {
            if (!this.InEnabled(log.LogLevel)) return;
            try
            {
                foreach (var output in this.Config.LogOutputs)
                {
                    output.Write(log);
                }
            }
            catch (Exception)
            {
                if (this.Config.NoThrow) return;
                throw;
            }
        }

        private async Task LogAsync(FoghornLog log)
        {
            if (!this.InEnabled(log.LogLevel)) return;
            try
            {
                var tasks = this.Config.LogOutputs.Select(o => o.WriteAsync(log));
                await Task.WhenAll(tasks);
            }
            catch (Exception)
            {
                if (this.Config.NoThrow) return;
                throw;
            }
        }

        private LogAttributes AppendException(LogAttributes attr, Exception ex)
        {
            var copy = attr.Clone();
            copy.Add("ExceptionType", ex.GetType().Name);
            copy.Add("ExceptionMessage", ex.Message);
            copy.Add("ExceptionSource", ex.Source);
            copy.Add("ExceptionStacktrace", ex.StackTrace);
            return copy;
        }
    }
}
