using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public class ConsoleOutput : ILogOutput
    {
        public void Dispose()
        {
            // no-op
        }

        public void Write(FoghornLog log)
        {
            throw new System.NotImplementedException();
        }

        public Task WriteAsync(FoghornLog log)
        {
            throw new System.NotImplementedException();
        }
    }
}
