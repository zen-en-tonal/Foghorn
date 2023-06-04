using Foghorn.Log;

namespace Foghorn.Logging
{
    public class ContextLogOutputProvider : IContextLogOutputProvider
    {
        private readonly IFoghornLoggerFilter Filter;

        private readonly ILogOutputProvider Provider;

        public ContextLogOutputProvider(
            IFoghornLoggerFilter filter,
            ILogOutputProvider provider)
        {
            Filter = filter;
            Provider = provider;
        }

        public ILogOutput CreateLogOutput()
        {
            return this.Provider.CreateLogOutput();
        }

        public bool IsEnabledOn(FoghornLog log)
        {
            return this.Filter.IsEnabledOn(log);
        }
    }
}
