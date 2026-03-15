using Newtonsoft.Json;

namespace Gabp.Runtime
{
    public class GabpClientInfo
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string? Version { get; set; }
    }

    public class GabpAppInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;
    }

    public class GabpServerInfo
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string? Version { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public string? Author { get; set; }
    }

    public class SessionHelloParams
    {
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;

        [JsonProperty("bridgeVersion")]
        public string BridgeVersion { get; set; } = string.Empty;

        [JsonProperty("platform")]
        public string Platform { get; set; } = string.Empty;

        [JsonProperty("launchId")]
        public string LaunchId { get; set; } = string.Empty;

        [JsonProperty("clientInfo", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("agentId")]
        public string AgentId { get; set; } = string.Empty;

        [JsonProperty("app")]
        public GabpAppInfo App { get; set; } = new GabpAppInfo();

        [JsonProperty("capabilities")]
        public GabpCapabilities Capabilities { get; set; } = new GabpCapabilities();

        [JsonProperty("schemaVersion")]
        public string SchemaVersion { get; set; } = RuntimeMetadata.TargetGabpSchemaVersion;

        [JsonProperty("serverInfo", NullValueHandling = NullValueHandling.Ignore)]
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
