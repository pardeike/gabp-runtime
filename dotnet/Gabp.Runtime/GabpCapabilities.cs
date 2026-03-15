using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public class GabpCapabilities
    {
        [Newtonsoft.Json.JsonProperty("methods")]
        [JsonPropertyName("methods")]
        public List<string> Methods { get; set; } = new List<string>();

        [Newtonsoft.Json.JsonProperty("events")]
        [JsonPropertyName("events")]
        public List<string> Events { get; set; } = new List<string>();

        [Newtonsoft.Json.JsonProperty("resources")]
        [JsonPropertyName("resources")]
        public List<string> Resources { get; set; } = new List<string>();

        [Newtonsoft.Json.JsonProperty("extensions", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("extensions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, JsonElement>? Extensions { get; set; }

        [Newtonsoft.Json.JsonProperty("limits", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("limits")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GabpLimits? Limits { get; set; }
    }

    public class GabpLimits
    {
        [Newtonsoft.Json.JsonProperty("maxMessageSize", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("maxMessageSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxMessageSize { get; set; }

        [Newtonsoft.Json.JsonProperty("maxConcurrentRequests", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("maxConcurrentRequests")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxConcurrentRequests { get; set; }

        [Newtonsoft.Json.JsonProperty("requestTimeout", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("requestTimeout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RequestTimeout { get; set; }
    }
}
