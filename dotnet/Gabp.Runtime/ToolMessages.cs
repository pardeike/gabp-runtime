using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public class GabpToolDescriptor
    {
        [Newtonsoft.Json.JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("inputSchema")]
        [JsonPropertyName("inputSchema")]
        public JsonElement InputSchema { get; set; }

        [Newtonsoft.Json.JsonProperty("outputSchema")]
        [JsonPropertyName("outputSchema")]
        public JsonElement OutputSchema { get; set; }

        [Newtonsoft.Json.JsonProperty("tags", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("tags")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Tags { get; set; }

        [Newtonsoft.Json.JsonProperty("deprecated", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("deprecated")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Deprecated { get; set; }

        [Newtonsoft.Json.JsonProperty("version", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Version { get; set; }
    }

    public class ToolsCallParams
    {
        [Newtonsoft.Json.JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("arguments", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("arguments")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JsonElement? Arguments { get; set; }
    }

    public class ToolsCallRequest : GabpRequestEnvelope<ToolsCallParams>
    {
        public ToolsCallRequest()
        {
            Method = GabpProtocol.ToolsCallMethod;
            Params = new ToolsCallParams();
        }
    }

    public class ToolsListResult
    {
        [Newtonsoft.Json.JsonProperty("tools")]
        [JsonPropertyName("tools")]
        public List<GabpToolDescriptor> Tools { get; set; } = new List<GabpToolDescriptor>();
    }

    public class ToolsListResponse : GabpResponseEnvelope<ToolsListResult>
    {
        public ToolsListResponse()
        {
            Result = new ToolsListResult();
        }
    }
}
