using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gabp.Runtime
{
    public class GabpError
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public JToken? Data { get; set; }
    }
}
