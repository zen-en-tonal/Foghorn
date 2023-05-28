using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public interface IOutput
    {
        void Write(FoghornLog log);

        Task WriteAsync(FoghornLog log);
    }
}