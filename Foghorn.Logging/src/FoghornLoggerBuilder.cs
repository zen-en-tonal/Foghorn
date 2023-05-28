using Foghorn.Log;

namespace Foghorn.Logging
{
    public class FoghornLoggerBuilder : FoghornLoggerConfiguration
    {
        public FoghornLoggerBuilder() { }

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
