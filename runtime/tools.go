package runtime

import "encoding/json"

type ToolDescriptor struct {
	Name         string          `json:"name"`
	Title        string          `json:"title"`
	Description  string          `json:"description"`
	InputSchema  json.RawMessage `json:"inputSchema"`
	OutputSchema json.RawMessage `json:"outputSchema"`
	Tags         []string        `json:"tags,omitempty"`
	Deprecated   *bool           `json:"deprecated,omitempty"`
	Version      string          `json:"version,omitempty"`
}

type ToolsCallParams struct {
	Name      string          `json:"name"`
	Arguments json.RawMessage `json:"arguments,omitempty"`
}

type ToolsCallRequest struct {
	RequestEnvelope[ToolsCallParams]
}

func NewToolsCallRequest(id string, params ToolsCallParams) ToolsCallRequest {
	return ToolsCallRequest{
		RequestEnvelope: NewRequestEnvelope(id, MethodToolsCall, params),
	}
}

type ToolsListResult struct {
	Tools []ToolDescriptor `json:"tools"`
}

type ToolsListResponse struct {
	ResponseEnvelope[ToolsListResult]
}

func NewToolsListResponse(id string, result ToolsListResult) ToolsListResponse {
	return ToolsListResponse{
		ResponseEnvelope: NewResponseEnvelopeSuccess(id, result),
	}
}
