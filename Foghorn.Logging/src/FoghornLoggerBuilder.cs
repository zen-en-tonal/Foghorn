using Foghorn.Log;

namespace Foghorn.Logging
{
    public class FoghornLoggerBuilder : FoghornLoggerConfiguration
    {
        public FoghornLoggerBuilder(string ident, string host)
        {
            if (string.IsNullOrEmpty(ident))
            {
                throw new System.ArgumentException(
                    $"'{nameof(ident)}' cannot be null or empty.",
                    nameof(ident));
            }

            if (string.IsNullOrEmpty(host))
            {
                throw new System.ArgumentException(
                    $"'{nameof(host)}' cannot be null or empty.",
                    nameof(host));
            }

            this.Ident = ident;
            this.Host = host;
        }

        public FoghornLoggerBuilder SetNoThrow()
        {
            this.NoThrow = true;
            return this;
        }

        public FoghornLoggerBuilder AddLogOutput(ILogOutput output)
        {
            this.LogOutputs.Add(output);
            return this;
        }

        public FoghornLoggerBuilder SetMinLogLevel(LogLevel logLevel)
        {
            this.MinLogLevel = logLevel;
            return this;
        }

        public FoghornLoggerBuilder UseConsole()
        {
            this.AddLogOutput(new ConsoleOutput());
            return this;
        }

        public FoghornLogger Build()
        {
            return new FoghornLogger(this);
        }
    }
}
