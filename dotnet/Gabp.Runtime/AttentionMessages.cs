using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gabp.Runtime
{
    public class GabpAttentionSample
    {
        [JsonProperty("level")]
        public string Level { get; set; } = string.Empty;

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("repeatCount")]
        public int RepeatCount { get; set; }

        [JsonProperty("latestSequence")]
        public int LatestSequence { get; set; }
    }

    public class GabpAttention
    {
        [JsonProperty("attentionId")]
        public string AttentionId { get; set; } = string.Empty;

        [JsonProperty("state")]
        public string State { get; set; } = string.Empty;

        [JsonProperty("severity")]
        public string Severity { get; set; } = string.Empty;

        [JsonProperty("blocking")]
        public bool Blocking { get; set; }

        [JsonProperty("stateInvalidated")]
        public bool StateInvalidated { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; } = string.Empty;

        [JsonProperty("causalOperationId", NullValueHandling = NullValueHandling.Ignore)]
        public string? CausalOperationId { get; set; }

        [JsonProperty("causalMethod", NullValueHandling = NullValueHandling.Ignore)]
        public string? CausalMethod { get; set; }

        [JsonProperty("openedAtSequence")]
        public int OpenedAtSequence { get; set; }

        [JsonProperty("latestSequence")]
        public int LatestSequence { get; set; }

        [JsonProperty("diagnosticsCursor", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiagnosticsCursor { get; set; }

        [JsonProperty("totalUrgentEntries")]
        public int TotalUrgentEntries { get; set; }

        [JsonProperty("sample", NullValueHandling = NullValueHandling.Ignore)]
        public List<GabpAttentionSample>? Sample { get; set; }
    }

    public class AttentionCurrentParams
    {
    }

    public class AttentionCurrentRequest : GabpRequestEnvelope<AttentionCurrentParams>
    {
        public AttentionCurrentRequest()
        {
            Method = GabpProtocol.AttentionCurrentMethod;
            Params = new AttentionCurrentParams();
        }
    }

    public class AttentionCurrentResult
    {
        [JsonProperty("attention")]
        public GabpAttention? Attention { get; set; }
    }

    public class AttentionCurrentResponse : GabpResponseEnvelope<AttentionCurrentResult>
    {
        public AttentionCurrentResponse()
        {
            Result = new AttentionCurrentResult();
        }
    }

    public class AttentionAckParams
    {
        [JsonProperty("attentionId")]
        public string AttentionId { get; set; } = string.Empty;
    }

    public class AttentionAckRequest : GabpRequestEnvelope<AttentionAckParams>
    {
        public AttentionAckRequest()
        {
            Method = GabpProtocol.AttentionAckMethod;
            Params = new AttentionAckParams();
        }
    }

    public class AttentionAckResult
    {
        [JsonProperty("acknowledged")]
        public bool Acknowledged { get; set; }

        [JsonProperty("attentionId")]
        public string AttentionId { get; set; } = string.Empty;

        [JsonProperty("currentAttention")]
        public GabpAttention? CurrentAttention { get; set; }
    }

    public class AttentionAckResponse : GabpResponseEnvelope<AttentionAckResult>
    {
        public AttentionAckResponse()
        {
            Result = new AttentionAckResult();
        }
    }
}
