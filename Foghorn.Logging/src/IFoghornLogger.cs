using System;
using System.Threading.Tasks;
using Foghorn.Log;

namespace Foghorn.Logging
{
    public interface IFoghornLogger
    {
        void Log(LogLevel logLevel, string message, Exception ex, LogAttributes attr);

        Task LogAsync(LogLevel logLevel, string message, Exception ex, LogAttributes attr);
    }
}