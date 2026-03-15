package runtime

import "encoding/json"

type Error struct {
	Code    int             `json:"code"`
	Message string          `json:"message"`
	Data    json.RawMessage `json:"data,omitempty"`
}

type RequestEnvelope[T any] struct {
	Version string `json:"v"`
	ID      string `json:"id"`
	Type    string `json:"type"`
	Method  string `json:"method"`
	Params  T      `json:"params"`
}

type ResponseEnvelope[T any] struct {
	Version string `json:"v"`
	ID      string `json:"id"`
	Type    string `json:"type"`
	Result  *T     `json:"result,omitempty"`
	Error   *Error `json:"error,omitempty"`
}

type EventEnvelope[T any] struct {
	Version string `json:"v"`
	ID      string `json:"id"`
	Type    string `json:"type"`
	Channel string `json:"channel"`
	Seq     int    `json:"seq"`
	Payload T      `json:"payload"`
}

func NewRequestEnvelope[T any](id string, method string, params T) RequestEnvelope[T] {
	return RequestEnvelope[T]{
		Version: EnvelopeVersion,
		ID:      id,
		Type:    MessageTypeRequest,
		Method:  method,
		Params:  params,
	}
}

func NewResponseEnvelopeSuccess[T any](id string, result T) ResponseEnvelope[T] {
	return ResponseEnvelope[T]{
		Version: EnvelopeVersion,
		ID:      id,
		Type:    MessageTypeResponse,
		Result:  &result,
	}
}

func NewResponseEnvelopeError(id string, err Error) ResponseEnvelope[json.RawMessage] {
	return ResponseEnvelope[json.RawMessage]{
		Version: EnvelopeVersion,
		ID:      id,
		Type:    MessageTypeResponse,
		Error:   &err,
	}
}
