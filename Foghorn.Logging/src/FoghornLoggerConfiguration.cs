using System.Collections.Generic;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public class FoghornLoggerConfiguration
    {
        public bool NoThrow = false;

        public LogLevel MinLogLevel = LogLevel.Information;

        public ICollection<IOutput> Outputs = new List<IOutput>();
    }
}
