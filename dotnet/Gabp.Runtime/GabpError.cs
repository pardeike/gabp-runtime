using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public class GabpError
    {
        [Newtonsoft.Json.JsonProperty("code")]
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("data", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JsonElement? Data { get; set; }
    }
}
