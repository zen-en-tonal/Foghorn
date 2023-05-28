using System;
using Foghorn.Log;

namespace Foghorn.Logging.Slack
{
    public class SlackOutputProvider : ILogOutputProvider
    {
        private readonly Uri BaseUri;

        private readonly Func<FoghornLog, string> Format;

        public SlackOutputProvider(Uri baseUri)
        {
            this.BaseUri = baseUri;
            this.Format = SlackLogOutputFormat.Format;
        }

        public SlackOutputProvider(Uri baseUri, Func<FoghornLog, string> format)
        {
            this.BaseUri = baseUri;
            this.Format = format;
        }

        public ILogOutput CreateLogOutput()
        {
            return new SlackLogOutput(this.Format)
            {
                BaseAddress = this.BaseUri
            };
        }
    }
}
