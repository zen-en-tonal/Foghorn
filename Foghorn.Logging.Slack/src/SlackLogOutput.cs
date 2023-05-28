using System;
using System.Net.Http;
using System.Threading.Tasks;
using Foghorn.Log;
using Newtonsoft.Json;

namespace Foghorn.Logging.Slack
{
    public class SlackLogOutput : HttpClient, ILogOutput
    {
        private readonly Func<FoghornLog, string> Format;

        public SlackLogOutput(Func<FoghornLog, string> format)
        {
            this.Format = format;
        }

        public void Write(FoghornLog log)
        {
            this.WriteAsync(log).Wait();
        }

        public Task WriteAsync(FoghornLog log)
        {
            var content = new StringContent(this.Serialize(log));
            return this.PostAsync("", content);
        }

        private string Serialize(FoghornLog log)
        {
            return JsonConvert.SerializeObject(new
            {
                text = this.Format(log)
            });
        }
    }
}
