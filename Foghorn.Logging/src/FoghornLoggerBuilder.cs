using Foghorn.Log;

namespace Foghorn.Logging
{
    public class FoghornLoggerBuilder
    {
        private FoghornLoggerConfiguration Config;

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

            this.Config = new FoghornLoggerConfiguration();
            this.Config.Ident = ident;
            this.Config.Host = host;
        }

        public FoghornLoggerBuilder NoThrow()
        {
            this.Config.NoThrow = true;
            return this;
        }

        public FoghornLoggerBuilder AddLogOutput(ILogOutputProvider output)
        {
            this.Config.LogOutputs.Add(output);
            return this;
        }

        public FoghornLoggerBuilder MinLogLevel(LogLevel logLevel)
        {
            this.Config.MinLogLevel = logLevel;
            return this;
        }

        public FoghornLogger Build()
        {
            return new FoghornLogger(this.Config);
        }
    }
}
