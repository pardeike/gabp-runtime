using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public sealed class GabpCapabilities
    {
        [JsonPropertyName("methods")]
        public List<string> Methods { get; set; } = new List<string>();

        [JsonPropertyName("events")]
        public List<string> Events { get; set; } = new List<string>();

        [JsonPropertyName("resources")]
        public List<string> Resources { get; set; } = new List<string>();

        [JsonPropertyName("extensions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, JsonElement>? Extensions { get; set; }

        [JsonPropertyName("limits")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GabpLimits? Limits { get; set; }
    }

    public sealed class GabpLimits
    {
        [JsonPropertyName("maxMessageSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxMessageSize { get; set; }

        [JsonPropertyName("maxConcurrentRequests")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxConcurrentRequests { get; set; }

        [JsonPropertyName("requestTimeout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RequestTimeout { get; set; }
    }
}
