package runtime

const (
	EnvelopeVersion = "gabp/1"

	MessageTypeRequest  = "request"
	MessageTypeResponse = "response"
	MessageTypeEvent    = "event"

	MethodSessionHello     = "session/hello"
	MethodToolsCall        = "tools/call"
	MethodToolsList        = "tools/list"
	MethodAttentionCurrent = "attention/current"
	MethodAttentionAck     = "attention/ack"

	ChannelAttentionOpened  = "attention/opened"
	ChannelAttentionUpdated = "attention/updated"
	ChannelAttentionCleared = "attention/cleared"
)
