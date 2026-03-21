package runtime

type AttentionSample struct {
	Level          string `json:"level"`
	Message        string `json:"message"`
	RepeatCount    int    `json:"repeatCount"`
	LatestSequence int    `json:"latestSequence"`
}

type Attention struct {
	AttentionID        string            `json:"attentionId"`
	State              string            `json:"state"`
	Severity           string            `json:"severity"`
	Blocking           bool              `json:"blocking"`
	StateInvalidated   bool              `json:"stateInvalidated"`
	Summary            string            `json:"summary"`
	CausalOperationID  string            `json:"causalOperationId,omitempty"`
	CausalMethod       string            `json:"causalMethod,omitempty"`
	OpenedAtSequence   int               `json:"openedAtSequence"`
	LatestSequence     int               `json:"latestSequence"`
	DiagnosticsCursor  *int              `json:"diagnosticsCursor,omitempty"`
	TotalUrgentEntries int               `json:"totalUrgentEntries"`
	Sample             []AttentionSample `json:"sample,omitempty"`
}

type AttentionCurrentParams struct{}

type AttentionCurrentRequest struct {
	RequestEnvelope[AttentionCurrentParams]
}

func NewAttentionCurrentRequest(id string) AttentionCurrentRequest {
	return AttentionCurrentRequest{
		RequestEnvelope: NewRequestEnvelope(id, MethodAttentionCurrent, AttentionCurrentParams{}),
	}
}

type AttentionCurrentResult struct {
	Attention *Attention `json:"attention"`
}

type AttentionCurrentResponse struct {
	ResponseEnvelope[AttentionCurrentResult]
}

func NewAttentionCurrentResponse(id string, result AttentionCurrentResult) AttentionCurrentResponse {
	return AttentionCurrentResponse{
		ResponseEnvelope: NewResponseEnvelopeSuccess(id, result),
	}
}

type AttentionAckParams struct {
	AttentionID string `json:"attentionId"`
}

type AttentionAckRequest struct {
	RequestEnvelope[AttentionAckParams]
}

func NewAttentionAckRequest(id string, params AttentionAckParams) AttentionAckRequest {
	return AttentionAckRequest{
		RequestEnvelope: NewRequestEnvelope(id, MethodAttentionAck, params),
	}
}

type AttentionAckResult struct {
	Acknowledged     bool       `json:"acknowledged"`
	AttentionID      string     `json:"attentionId"`
	CurrentAttention *Attention `json:"currentAttention"`
}

type AttentionAckResponse struct {
	ResponseEnvelope[AttentionAckResult]
}

func NewAttentionAckResponse(id string, result AttentionAckResult) AttentionAckResponse {
	return AttentionAckResponse{
		ResponseEnvelope: NewResponseEnvelopeSuccess(id, result),
	}
}
