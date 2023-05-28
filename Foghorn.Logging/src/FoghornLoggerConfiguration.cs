using System.Collections.Generic;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public class FoghornLoggerConfiguration
    {
        public string Ident;

        public string Host;

        public bool NoThrow = false;

        public ICollection<KeyValuePair<LogLevel, ILogOutputProvider>> LogOutputs =
            new List<KeyValuePair<LogLevel, ILogOutputProvider>>();
    }
}
