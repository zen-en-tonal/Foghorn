using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public class FoghornLogger : IFoghornLogger
    {
        private readonly FoghornLoggerConfiguration Config;

        internal FoghornLogger(FoghornLoggerConfiguration config)
        {
            this.Config = config;
        }

        private IEnumerable<ILogOutputProvider> GetEnabledOutputProviders(FoghornLog log)
        {
            return this.Config.LogOutputs
                .Where(l => l.Key.IsEnabledOn(log))
                .Select(l => l.Value);
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
            foreach (var provider in this.GetEnabledOutputProviders(log))
            {
                this.TryLog(log, provider);
            }
        }

        private void TryLog(FoghornLog log, ILogOutputProvider provider)
        {
            try
            {
                using (var output = provider.CreateLogOutput())
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

        private Task LogAsync(FoghornLog log)
        {
            var tasks = this.GetEnabledOutputProviders(log)
                .Select(provider => this.TryLogAsync(log, provider));
            return Task.WhenAll(tasks);
        }

        private Task TryLogAsync(FoghornLog log, ILogOutputProvider provider)
        {
            try
            {
                using (var output = provider.CreateLogOutput())
                {
                    return output.WriteAsync(log);
                }
            }
            catch (Exception)
            {
                if (this.Config.NoThrow) return Task.FromResult(0);
                throw;
            }
        }

        private LogAttributes AppendException(LogAttributes attr, Exception ex)
        {
            if (ex is null) return attr;
            var copy = attr.Clone();
            copy.Add("ExceptionType", ex.GetType().Name);
            copy.Add("ExceptionMessage", ex.Message);
            copy.Add("ExceptionSource", ex.Source);
            copy.Add("ExceptionStacktrace", ex.StackTrace);
            return copy;
        }
    }
}
