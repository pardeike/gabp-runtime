using Newtonsoft.Json;

namespace Gabp.Runtime
{
    public class GabpRequestEnvelope<TParams>
    {
        [JsonProperty("v")]
        public string Version { get; set; } = GabpProtocol.EnvelopeVersion;

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = GabpProtocol.RequestType;

        [JsonProperty("method")]
        public string Method { get; set; } = string.Empty;

        [JsonProperty("params")]
        public TParams Params { get; set; } = default!;
    }

    public class GabpResponseEnvelope<TResult>
    {
        [JsonProperty("v")]
        public string Version { get; set; } = GabpProtocol.EnvelopeVersion;

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = GabpProtocol.ResponseType;

        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public TResult? Result { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public GabpError? Error { get; set; }
    }

    public class GabpEventEnvelope<TPayload>
    {
        [JsonProperty("v")]
        public string Version { get; set; } = GabpProtocol.EnvelopeVersion;

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = GabpProtocol.EventType;

        [JsonProperty("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonProperty("seq")]
        public int Sequence { get; set; }

        [JsonProperty("payload")]
        public TPayload Payload { get; set; } = default!;
    }
}
