using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public class GabpRequestEnvelope<TParams>
    {
        [JsonPropertyName("v")]
        public string Version { get; set; } = GabpProtocol.EnvelopeVersion;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = GabpProtocol.RequestType;

        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        [JsonPropertyName("params")]
        public TParams Params { get; set; } = default!;
    }

    public class GabpResponseEnvelope<TResult>
    {
        [JsonPropertyName("v")]
        public string Version { get; set; } = GabpProtocol.EnvelopeVersion;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = GabpProtocol.ResponseType;

        [JsonPropertyName("result")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TResult? Result { get; set; }

        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GabpError? Error { get; set; }
    }

    public class GabpEventEnvelope<TPayload>
    {
        [JsonPropertyName("v")]
        public string Version { get; set; } = GabpProtocol.EnvelopeVersion;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = GabpProtocol.EventType;

        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyName("seq")]
        public int Sequence { get; set; }

        [JsonPropertyName("payload")]
        public TPayload Payload { get; set; } = default!;
    }
}
