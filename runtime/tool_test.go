package runtime

import "testing"

func TestToolsCallFixture(t *testing.T) {
	data := loadValidFixture(t, "003_tools_call.json")

	var request ToolsCallRequest
	if err := Unmarshal(data, &request); err != nil {
		t.Fatalf("unmarshal tools/call fixture: %v", err)
	}

	if request.Method != MethodToolsCall {
		t.Fatalf("unexpected method: %s", request.Method)
	}

	if request.Params.Name != "test/tool" {
		t.Fatalf("unexpected tool name: %s", request.Params.Name)
	}

	if string(request.Params.Arguments) == "" {
		t.Fatal("expected tool arguments")
	}
}

func TestEventFixture(t *testing.T) {
	data := loadValidFixture(t, "004_event_message.json")

	var event EventEnvelope[map[string]string]
	if err := Unmarshal(data, &event); err != nil {
		t.Fatalf("unmarshal event fixture: %v", err)
	}

	if event.Type != MessageTypeEvent {
		t.Fatalf("unexpected type: %s", event.Type)
	}

	if event.Channel != "test/event" {
		t.Fatalf("unexpected channel: %s", event.Channel)
	}

	if event.Payload["data"] != "test event payload" {
		t.Fatalf("unexpected payload: %#v", event.Payload)
	}
}

func TestErrorFixture(t *testing.T) {
	data := loadValidFixture(t, "005_error_response.json")

	var response ResponseEnvelope[map[string]string]
	if err := Unmarshal(data, &response); err != nil {
		t.Fatalf("unmarshal error fixture: %v", err)
	}

	if response.Error == nil {
		t.Fatal("expected error")
	}

	if response.Error.Code != -32601 {
		t.Fatalf("unexpected error code: %d", response.Error.Code)
	}

	if response.Result != nil {
		t.Fatalf("expected nil result, got %#v", response.Result)
	}
}

func TestToolsListFixtureRoundTrip(t *testing.T) {
	data := loadValidFixture(t, "006_tools_list_response.json")

	var response ToolsListResponse
	if err := Unmarshal(data, &response); err != nil {
		t.Fatalf("unmarshal tools/list fixture: %v", err)
	}

	serialized, err := Marshal(response)
	if err != nil {
		t.Fatalf("marshal tools/list fixture: %v", err)
	}

	var roundTrip ToolsListResponse
	if err := Unmarshal(serialized, &roundTrip); err != nil {
		t.Fatalf("unmarshal round-tripped tools/list fixture: %v", err)
	}

	if roundTrip.Result == nil || len(roundTrip.Result.Tools) != 1 {
		t.Fatalf("unexpected tools result: %#v", roundTrip.Result)
	}

	if roundTrip.Result.Tools[0].Name != "inventory/get" {
		t.Fatalf("unexpected tool name: %s", roundTrip.Result.Tools[0].Name)
	}
}
