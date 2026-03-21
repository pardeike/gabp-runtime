package runtime

import (
	"os"
	"path/filepath"
	"testing"
)

func TestSessionHelloFixture(t *testing.T) {
	data := loadValidFixture(t, "001_session_hello.json")

	var request SessionHelloRequest
	if err := Unmarshal(data, &request); err != nil {
		t.Fatalf("unmarshal hello fixture: %v", err)
	}

	if request.Version != EnvelopeVersion {
		t.Fatalf("unexpected version: %s", request.Version)
	}

	if request.Type != MessageTypeRequest {
		t.Fatalf("unexpected message type: %s", request.Type)
	}

	if request.Method != MethodSessionHello {
		t.Fatalf("unexpected method: %s", request.Method)
	}

	if request.Params.Platform != "linux" {
		t.Fatalf("unexpected platform: %s", request.Params.Platform)
	}

	if request.Params.LaunchID != "550e8400-e29b-41d4-a716-446655440001" {
		t.Fatalf("unexpected launch id: %s", request.Params.LaunchID)
	}
}

func TestSessionWelcomeFixtureRoundTrip(t *testing.T) {
	data := loadValidFixture(t, "002_session_welcome.json")

	var response SessionWelcomeResponse
	if err := Unmarshal(data, &response); err != nil {
		t.Fatalf("unmarshal welcome fixture: %v", err)
	}

	serialized, err := Marshal(response)
	if err != nil {
		t.Fatalf("marshal welcome fixture: %v", err)
	}

	var roundTrip SessionWelcomeResponse
	if err := Unmarshal(serialized, &roundTrip); err != nil {
		t.Fatalf("unmarshal round-tripped welcome fixture: %v", err)
	}

	if roundTrip.Version != EnvelopeVersion {
		t.Fatalf("unexpected version: %s", roundTrip.Version)
	}

	if roundTrip.Type != MessageTypeResponse {
		t.Fatalf("unexpected type: %s", roundTrip.Type)
	}

	if roundTrip.Result == nil {
		t.Fatal("expected result")
	}

	if roundTrip.Result.AgentID != "test-mod" {
		t.Fatalf("unexpected agent id: %s", roundTrip.Result.AgentID)
	}

	if roundTrip.Result.App.Name != "TestGame" {
		t.Fatalf("unexpected app name: %s", roundTrip.Result.App.Name)
	}

	if len(roundTrip.Result.Capabilities.Methods) != 1 || roundTrip.Result.Capabilities.Methods[0] != MethodSessionHello {
		t.Fatalf("unexpected capabilities methods: %#v", roundTrip.Result.Capabilities.Methods)
	}

	if len(roundTrip.Result.Capabilities.Events) != 0 {
		t.Fatalf("unexpected capabilities events: %#v", roundTrip.Result.Capabilities.Events)
	}

	if len(roundTrip.Result.Capabilities.Resources) != 0 {
		t.Fatalf("unexpected capabilities resources: %#v", roundTrip.Result.Capabilities.Resources)
	}

	if roundTrip.Error != nil {
		t.Fatalf("unexpected error: %#v", roundTrip.Error)
	}
}

func loadValidFixture(t *testing.T, fileName string) []byte {
	t.Helper()

	path := filepath.Join("..", "testdata", "gabp", TargetGabpSchemaVersion, "conformance", "valid", fileName)
	data, err := os.ReadFile(path)
	if err != nil {
		t.Fatalf("read fixture %s: %v", path, err)
	}

	return data
}
