using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gabp.Runtime
{
    public class GabpToolDescriptor
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("inputSchema")]
        public JToken InputSchema { get; set; } = new JObject();

        [JsonProperty("outputSchema")]
        public JToken OutputSchema { get; set; } = new JObject();

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? Tags { get; set; }

        [JsonProperty("deprecated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deprecated { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string? Version { get; set; }
    }

    public class ToolsCallParams
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
        public JToken? Arguments { get; set; }
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
        [JsonProperty("tools")]
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
