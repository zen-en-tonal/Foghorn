using System.Collections.Generic;

namespace Foghorn.Logging.Gelf
{
    public class AdditionalFields
    {
        private readonly Dictionary<string, string> Dict =
            new Dictionary<string, string>();

        /// <summary>
        /// Initialize with Dictionary.
        /// The keys will be added `_` as prefix.
        /// </summary>
        /// <param name="dict"></param>
        public AdditionalFields(Dictionary<string, string> dict)
        {
            foreach (var tuple in dict)
            {
                this.Dict.Add($"_{tuple.Key}", tuple.Value);
            }
        }

        public Dictionary<string, string> ToDict()
        {
            return this.Dict;
        }
    }
}