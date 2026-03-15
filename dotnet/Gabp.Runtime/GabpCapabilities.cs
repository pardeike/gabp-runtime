using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gabp.Runtime
{
    public class GabpCapabilities
    {
        [JsonProperty("methods")]
        public List<string> Methods { get; set; } = new List<string>();

        [JsonProperty("events")]
        public List<string> Events { get; set; } = new List<string>();

        [JsonProperty("resources")]
        public List<string> Resources { get; set; } = new List<string>();

        [JsonProperty("extensions", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object>? Extensions { get; set; }

        [JsonProperty("limits", NullValueHandling = NullValueHandling.Ignore)]
        public GabpLimits? Limits { get; set; }
    }

    public class GabpLimits
    {
        [JsonProperty("maxMessageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxMessageSize { get; set; }

        [JsonProperty("maxConcurrentRequests", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxConcurrentRequests { get; set; }

        [JsonProperty("requestTimeout", NullValueHandling = NullValueHandling.Ignore)]
        public int? RequestTimeout { get; set; }
    }
}
