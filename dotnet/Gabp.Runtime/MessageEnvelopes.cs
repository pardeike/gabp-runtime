using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public class GabpRequestEnvelope<TParams>
    {
        [Newtonsoft.Json.JsonProperty("v")]
        [JsonPropertyName("v")]
        public string Version { get; set; } = GabpProtocol.EnvelopeVersion;

        [Newtonsoft.Json.JsonProperty("id")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; } = GabpProtocol.RequestType;

        [Newtonsoft.Json.JsonProperty("method")]
        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("params")]
        [JsonPropertyName("params")]
        public TParams Params { get; set; } = default!;
    }

    public class GabpResponseEnvelope<TResult>
    {
        [Newtonsoft.Json.JsonProperty("v")]
        [JsonPropertyName("v")]
        public string Version { get; set; } = GabpProtocol.EnvelopeVersion;

        [Newtonsoft.Json.JsonProperty("id")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; } = GabpProtocol.ResponseType;

        [Newtonsoft.Json.JsonProperty("result", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("result")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TResult? Result { get; set; }

        [Newtonsoft.Json.JsonProperty("error", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GabpError? Error { get; set; }
    }

    public class GabpEventEnvelope<TPayload>
    {
        [Newtonsoft.Json.JsonProperty("v")]
        [JsonPropertyName("v")]
        public string Version { get; set; } = GabpProtocol.EnvelopeVersion;

        [Newtonsoft.Json.JsonProperty("id")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; } = GabpProtocol.EventType;

        [Newtonsoft.Json.JsonProperty("channel")]
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("seq")]
        [JsonPropertyName("seq")]
        public int Sequence { get; set; }

        [Newtonsoft.Json.JsonProperty("payload")]
        [JsonPropertyName("payload")]
        public TPayload Payload { get; set; } = default!;
    }
}
