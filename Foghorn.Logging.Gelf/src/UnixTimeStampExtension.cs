using System;

namespace Foghorn.Logging.Gelf
{
    static class UnixTimeStampExtension
    {
        static readonly DateTime OFFSET = new DateTime(1970, 1, 1);

        /// <summary>
        /// Convert the DateTime into the Unix timestamp 
        /// that includes milliseconds in the after the decimal point.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static double ToUnixTimeStamp(this DateTime self)
        {
            return self.Subtract(OFFSET).TotalSeconds;
        }
    }
}