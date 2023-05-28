using System;
using System.Linq;
using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public class FoghornLogger
    {
        private readonly FoghornLoggerConfiguration Config;

        internal FoghornLogger(FoghornLoggerConfiguration config)
        {
            this.Config = config;
        }

        public bool InEnabled(LogLevel logLevel)
        {
            return logLevel >= this.Config.MinLogLevel;
        }

        public void Log(
            LogLevel logLevel,
            string message,
            LogAttributes attributes)
        {
            this.Log(new FoghornLog(
                this.Config.Ident, logLevel, message,
                this.Config.Host, DateTime.Now, attributes
            ));
        }

        public void Log(
            LogLevel logLevel,
            string message,
            Exception e,
            LogAttributes attributes)
        {
            this.Log(new FoghornLog(
                this.Config.Ident, logLevel, message,
                this.Config.Host, DateTime.Now, this.AppendException(attributes, e)
            ));
        }

        public Task LogAsync(
            LogLevel logLevel,
            string message,
            LogAttributes attributes)
        {
            return this.LogAsync(new FoghornLog(
                this.Config.Ident, logLevel, message,
                this.Config.Host, DateTime.Now, attributes
            ));
        }

        public Task LogAsync(
            LogLevel logLevel,
            string message,
            Exception e,
            LogAttributes attributes)
        {
            return this.LogAsync(new FoghornLog(
                this.Config.Ident, logLevel, message,
                this.Config.Host, DateTime.Now, this.AppendException(attributes, e)
            ));
        }

        private void Log(FoghornLog log)
        {
            if (!this.InEnabled(log.LogLevel)) return;
            try
            {
                foreach (var provider in this.Config.LogOutputs)
                {
                    using (var output = provider.CreateLogOutput())
                    {
                        output.Write(log);
                    }
                }
            }
            catch (Exception)
            {
                if (this.Config.NoThrow) return;
                throw;
            }
        }

        private Task LogAsync(FoghornLog log)
        {
            if (!this.InEnabled(log.LogLevel)) return Task.FromResult(0);
            try
            {
                var tasks = this.Config.LogOutputs.Select(provider =>
                {
                    using (var output = provider.CreateLogOutput())
                    {
                        return output.WriteAsync(log);
                    }
                });
                return Task.WhenAll(tasks);
            }
            catch (Exception)
            {
                if (this.Config.NoThrow) return Task.FromResult(0);
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
