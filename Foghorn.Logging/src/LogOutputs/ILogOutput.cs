using System;
using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public interface ILogOutput : IDisposable
    {
        void Write(FoghornLog log);

        Task WriteAsync(FoghornLog log);
    }
}