using Foghorn.Log;

namespace Foghorn.Logging
{
    public interface IFoghornLoggerFilter
    {
        /// <summary>
        /// Returns true if log is matched the condition to output.
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        bool IsEnabledOn(FoghornLog log);
    }
}
