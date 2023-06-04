using System.Collections.Generic;

namespace Foghorn.Logging
{
    public class FoghornLoggerConfiguration
    {
        public string Ident;

        public string Host;

        public bool NoThrow = false;

        public ICollection<IContextLogOutputProvider> LogOutputs =
            new List<IContextLogOutputProvider>();
    }
}
