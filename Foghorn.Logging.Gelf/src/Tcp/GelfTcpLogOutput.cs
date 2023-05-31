using System.Threading.Tasks;
using Foghorn.Log;
using System.Net.Sockets;
using System;

namespace Foghorn.Logging.Gelf.Tcp
{
    public class GelfTcpLogOutput : TcpClient, ILogOutput
    {
        private readonly Func<FoghornLog, GelfPayload> Format;

        public GelfTcpLogOutput(
            string hostname,
            int port,
            Func<FoghornLog, GelfPayload> format) : base(hostname, port)
        {
            this.Format = format;
        }

        public void Write(FoghornLog log)
        {
            var payload = this.Format(log);
            using (var stream = this.GetStream())
            {
                stream.Write(payload.ToJsonBytes(), 0, payload.ToJsonBytes().Length);
            }
        }

        public Task WriteAsync(FoghornLog log)
        {
            var payload = this.Format(log);
            using (var stream = this.GetStream())
            {
                return stream.WriteAsync(payload.ToJsonBytes(), 0, payload.ToJsonBytes().Length);
            }
        }
    }
}
