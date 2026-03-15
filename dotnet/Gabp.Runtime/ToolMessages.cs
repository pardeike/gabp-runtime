using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public sealed class GabpToolDescriptor
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("inputSchema")]
        public JsonElement InputSchema { get; set; }

        [JsonPropertyName("outputSchema")]
        public JsonElement OutputSchema { get; set; }

        [JsonPropertyName("tags")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Tags { get; set; }

        [JsonPropertyName("deprecated")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Deprecated { get; set; }

        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Version { get; set; }
    }

    public sealed class ToolsCallParams
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("arguments")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JsonElement? Arguments { get; set; }
    }

    public sealed class ToolsCallRequest : GabpRequestEnvelope<ToolsCallParams>
    {
        public ToolsCallRequest()
        {
            Method = GabpProtocol.ToolsCallMethod;
            Params = new ToolsCallParams();
        }
    }

    public sealed class ToolsListResult
    {
        [JsonPropertyName("tools")]
        public List<GabpToolDescriptor> Tools { get; set; } = new List<GabpToolDescriptor>();
    }

    public sealed class ToolsListResponse : GabpResponseEnvelope<ToolsListResult>
    {
        public ToolsListResponse()
        {
            Result = new ToolsListResult();
        }
    }
}
