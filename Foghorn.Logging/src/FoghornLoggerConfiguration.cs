using System.Collections.Generic;

namespace Foghorn.Logging
{
    public class FoghornLoggerConfiguration
    {
        public string Ident;

        public string Host;

        public bool NoThrow = false;

        public ICollection<KeyValuePair<IFoghornLoggerFilter, ILogOutputProvider>> LogOutputs =
            new List<KeyValuePair<IFoghornLoggerFilter, ILogOutputProvider>>();
    }
}
