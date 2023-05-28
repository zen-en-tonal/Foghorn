using Foghorn.Log;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Foghorn.Logging
{
    public static class FoghornJsonSerializeExtension
    {
        public static string SerializeJson(this FoghornLog log)
        {
            return JsonConvert.SerializeObject(
                log,
                new StringEnumConverter()
            );
        }
    }
}