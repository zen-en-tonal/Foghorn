using System.Collections.Generic;
using System.Text;
using Foghorn.Log;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Foghorn.Logging.Gelf
{
    // https://go2docs.graylog.org/5-0/getting_in_log_data/gelf.html?tocpath=Getting%20in%20Log%20Data%7CLog%20Sources%7CGELF%7C_____0
    public class GelfPayload
    {
        const string Version = "1.1";

        public string Host;

        public string ShortMessage;

        public string FullMessage;

        public double Timestamp;

        public GelfLogLevel Level = GelfLogLevel.Alert;

        public AdditionalFields AdditionalFields;

        /// <summary>
        /// Creates the instance of GelfPayload using FoghornLog instance.
        /// </summary>
        /// <param name="log"></param>
        public GelfPayload(FoghornLog log)
        {
            this.Host = log.Host;
            this.ShortMessage = log.Message;
            this.FullMessage = log.Message;
            this.Timestamp = log.PublishedAt.ToUnixTimeStamp();
            this.Level = log.LogLevel.ToGelfLogLevel();
            this.AdditionalFields = new AdditionalFields(log.Attributes);
        }

        /// <summary>
        /// Creates the byte array of JSON serialized GelfPayload instance 
        /// that satisfies GELF specification.
        /// </summary>
        /// <returns>
        /// A JSON serialized byte array that satisfies GELF specification.
        /// </returns>
        public byte[] ToJsonBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToJsonString());
        }

        /// <summary>
        /// Serializes the GelfPayload instance.
        /// </summary>
        /// <returns>
        /// A JSON string that satisfies GELF specification.
        /// </returns>
        public string ToJsonString()
        {
            var constractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy(
                    processDictionaryKeys: true,
                    overrideSpecifiedNames: false)
            };
            var serializeSettings = new JsonSerializerSettings()
            {
                ContractResolver = constractResolver
            };
            return JsonConvert.SerializeObject(this.ToDict(), serializeSettings);
        }

        /// <summary>
        /// Creates the Dictionary that satisfies GELF specification.
        /// </summary>
        /// <returns>
        /// A Dictionary that satisfies GELF specification.
        /// </returns>
        public Dictionary<string, object> ToDict()
        {
            var dict = new Dictionary<string, object>()
            {
                ["Version"] = Version,
                ["Host"] = this.Host,
                ["ShortMessage"] = this.ShortMessage,
                ["FullMessage"] = this.FullMessage,
                ["Timestamp"] = this.Timestamp,
                ["Level"] = (int)this.Level
            };
            foreach (var tuple in this.AdditionalFields.ToDict())
            {
                dict.Add(tuple.Key, tuple.Value);
            }
            return dict;
        }
    }
}
