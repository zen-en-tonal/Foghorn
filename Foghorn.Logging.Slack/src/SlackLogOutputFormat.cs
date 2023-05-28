using System.Linq;
using Foghorn.Log;

namespace Foghorn.Logging.Slack
{
    public static class SlackLogOutputFormat
    {
        public static string Format(FoghornLog log)
        {
            var header = $"{log.Ident} {log.PublishedAt} | [{log.LogLevel.AsReadable()}] '{log.Message}' {log.Host}\n";
            return header + Attributes(log.Attributes);
        }

        static string Attributes(LogAttributes attr)
        {
            if (attr.IsEmpty()) return "";
            var tableHeader = "|||\n" + "|---|---|\n";
            return attr.Aggregate(tableHeader, (l, r) => l + $"|{r.Key}|{r.Value}|\n");
        }
    }
}
