using System.Collections.Generic;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public class FoghornLoggerConfiguration
    {
        public string Ident;

        public string Host;

        public bool NoThrow = false;

        public LogLevel MinLogLevel = LogLevel.Information;

        public ICollection<ILogOutputProvider> LogOutputs =
            new List<ILogOutputProvider>();
    }
}
