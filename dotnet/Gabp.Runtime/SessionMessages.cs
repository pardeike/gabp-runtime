using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public class GabpClientInfo
    {
        [Newtonsoft.Json.JsonProperty("name", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [Newtonsoft.Json.JsonProperty("version", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Version { get; set; }
    }

    public class GabpAppInfo
    {
        [Newtonsoft.Json.JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("version")]
        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;
    }

    public class GabpServerInfo
    {
        [Newtonsoft.Json.JsonProperty("name", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [Newtonsoft.Json.JsonProperty("version", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Version { get; set; }

        [Newtonsoft.Json.JsonProperty("author", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("author")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Author { get; set; }
    }

    public class SessionHelloParams
    {
        [Newtonsoft.Json.JsonProperty("token")]
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("bridgeVersion")]
        [JsonPropertyName("bridgeVersion")]
        public string BridgeVersion { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("platform")]
        [JsonPropertyName("platform")]
        public string Platform { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("launchId")]
        [JsonPropertyName("launchId")]
        public string LaunchId { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("clientInfo", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("clientInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GabpClientInfo? ClientInfo { get; set; }
    }

    public class SessionHelloRequest : GabpRequestEnvelope<SessionHelloParams>
    {
        public SessionHelloRequest()
        {
            Method = GabpProtocol.SessionHelloMethod;
            Params = new SessionHelloParams();
        }
    }

    public class SessionWelcomeResult
    {
        [Newtonsoft.Json.JsonProperty("agentId")]
        [JsonPropertyName("agentId")]
        public string AgentId { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("app")]
        [JsonPropertyName("app")]
        public GabpAppInfo App { get; set; } = new GabpAppInfo();

        [Newtonsoft.Json.JsonProperty("capabilities")]
        [JsonPropertyName("capabilities")]
        public GabpCapabilities Capabilities { get; set; } = new GabpCapabilities();

        [Newtonsoft.Json.JsonProperty("schemaVersion")]
        [JsonPropertyName("schemaVersion")]
        public string SchemaVersion { get; set; } = RuntimeMetadata.TargetGabpSchemaVersion;

        [Newtonsoft.Json.JsonProperty("serverInfo", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("serverInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GabpServerInfo? ServerInfo { get; set; }
    }

    public class SessionWelcomeResponse : GabpResponseEnvelope<SessionWelcomeResult>
    {
        public SessionWelcomeResponse()
        {
            Result = new SessionWelcomeResult();
        }
    }
}
