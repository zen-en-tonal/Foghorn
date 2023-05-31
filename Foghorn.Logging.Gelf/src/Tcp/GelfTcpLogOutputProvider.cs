namespace Foghorn.Logging.Gelf.Tcp
{
    public class GelfTcpLogOutputProvider : ILogOutputProvider
    {
        private readonly string Hostname;

        private readonly int Port;

        public GelfTcpLogOutputProvider(string hostname, int port)
        {
            Hostname = hostname;
            Port = port;
        }

        public ILogOutput CreateLogOutput()
        {
            return new GelfTcpLogOutput(
                this.Hostname,
                this.Port,
                (l) => new GelfPayload(l));
        }
    }
}
