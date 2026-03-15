package runtime

import "encoding/json"

type Limits struct {
	MaxMessageSize        *int `json:"maxMessageSize,omitempty"`
	MaxConcurrentRequests *int `json:"maxConcurrentRequests,omitempty"`
	RequestTimeout        *int `json:"requestTimeout,omitempty"`
}

type Capabilities struct {
	Methods    []string                   `json:"methods,omitempty"`
	Events     []string                   `json:"events,omitempty"`
	Resources  []string                   `json:"resources,omitempty"`
	Extensions map[string]json.RawMessage `json:"extensions,omitempty"`
	Limits     *Limits                    `json:"limits,omitempty"`
}

type ClientInfo struct {
	Name    string `json:"name,omitempty"`
	Version string `json:"version,omitempty"`
}

type AppInfo struct {
	Name    string `json:"name"`
	Version string `json:"version"`
}

type ServerInfo struct {
	Name    string `json:"name,omitempty"`
	Version string `json:"version,omitempty"`
	Author  string `json:"author,omitempty"`
}

type SessionHelloParams struct {
	Token         string      `json:"token"`
	BridgeVersion string      `json:"bridgeVersion"`
	Platform      string      `json:"platform"`
	LaunchID      string      `json:"launchId"`
	ClientInfo    *ClientInfo `json:"clientInfo,omitempty"`
}

type SessionHelloRequest struct {
	RequestEnvelope[SessionHelloParams]
}

func NewSessionHelloRequest(id string, params SessionHelloParams) SessionHelloRequest {
	return SessionHelloRequest{
		RequestEnvelope: NewRequestEnvelope(id, MethodSessionHello, params),
	}
}

type SessionWelcomeResult struct {
	AgentID       string       `json:"agentId"`
	App           AppInfo      `json:"app"`
	Capabilities  Capabilities `json:"capabilities"`
	SchemaVersion string       `json:"schemaVersion"`
	ServerInfo    *ServerInfo  `json:"serverInfo,omitempty"`
}

type SessionWelcomeResponse struct {
	ResponseEnvelope[SessionWelcomeResult]
}

func NewSessionWelcomeResponse(id string, result SessionWelcomeResult) SessionWelcomeResponse {
	return SessionWelcomeResponse{
		ResponseEnvelope: NewResponseEnvelopeSuccess(id, result),
	}
}
