package runtime

import "testing"

func TestAttentionCurrentFixture(t *testing.T) {
	data := loadValidFixture(t, "007_attention_current_response.json")

	var response AttentionCurrentResponse
	if err := Unmarshal(data, &response); err != nil {
		t.Fatalf("unmarshal attention/current fixture: %v", err)
	}

	if response.Result == nil || response.Result.Attention == nil {
		t.Fatalf("unexpected attention/current result: %#v", response.Result)
	}

	if response.Result.Attention.AttentionID != "attn_7" {
		t.Fatalf("unexpected attention id: %s", response.Result.Attention.AttentionID)
	}

	if response.Result.Attention.Blocking {
		t.Fatal("expected non-blocking attention item")
	}
}

func TestAttentionOpenedEventFixture(t *testing.T) {
	data := loadValidFixture(t, "008_attention_opened_event.json")

	var event EventEnvelope[Attention]
	if err := Unmarshal(data, &event); err != nil {
		t.Fatalf("unmarshal attention event fixture: %v", err)
	}

	if event.Channel != ChannelAttentionOpened {
		t.Fatalf("unexpected channel: %s", event.Channel)
	}

	if !event.Payload.Blocking {
		t.Fatal("expected blocking attention event")
	}

	if !event.Payload.StateInvalidated {
		t.Fatal("expected invalidated state in attention event")
	}
}

func TestAttentionAckFixture(t *testing.T) {
	data := loadValidFixture(t, "009_attention_ack_response.json")

	var response AttentionAckResponse
	if err := Unmarshal(data, &response); err != nil {
		t.Fatalf("unmarshal attention/ack fixture: %v", err)
	}

	if response.Result == nil {
		t.Fatal("expected attention/ack result")
	}

	if response.Result.Acknowledged {
		t.Fatal("expected unsuccessful acknowledgement")
	}

	if response.Result.AttentionID != "attn_missing" {
		t.Fatalf("unexpected requested attention id: %s", response.Result.AttentionID)
	}

	if response.Result.CurrentAttention == nil || response.Result.CurrentAttention.AttentionID != "attn_9" {
		t.Fatalf("unexpected current attention: %#v", response.Result.CurrentAttention)
	}
}
