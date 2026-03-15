using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public sealed class GabpClientInfo
    {
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Version { get; set; }
    }

    public sealed class GabpAppInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;
    }

    public sealed class GabpServerInfo
    {
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Version { get; set; }

        [JsonPropertyName("author")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Author { get; set; }
    }

    public sealed class SessionHelloParams
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        [JsonPropertyName("bridgeVersion")]
        public string BridgeVersion { get; set; } = string.Empty;

        [JsonPropertyName("platform")]
        public string Platform { get; set; } = string.Empty;

        [JsonPropertyName("launchId")]
        public string LaunchId { get; set; } = string.Empty;

        [JsonPropertyName("clientInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GabpClientInfo? ClientInfo { get; set; }
    }

    public sealed class SessionHelloRequest : GabpRequestEnvelope<SessionHelloParams>
    {
        public SessionHelloRequest()
        {
            Method = GabpProtocol.SessionHelloMethod;
            Params = new SessionHelloParams();
        }
    }

    public sealed class SessionWelcomeResult
    {
        [JsonPropertyName("agentId")]
        public string AgentId { get; set; } = string.Empty;

        [JsonPropertyName("app")]
        public GabpAppInfo App { get; set; } = new GabpAppInfo();

        [JsonPropertyName("capabilities")]
        public GabpCapabilities Capabilities { get; set; } = new GabpCapabilities();

        [JsonPropertyName("schemaVersion")]
        public string SchemaVersion { get; set; } = string.Empty;

        [JsonPropertyName("serverInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GabpServerInfo? ServerInfo { get; set; }
    }

    public sealed class SessionWelcomeResponse : GabpResponseEnvelope<SessionWelcomeResult>
    {
        public SessionWelcomeResponse()
        {
            Result = new SessionWelcomeResult();
        }
    }
}
