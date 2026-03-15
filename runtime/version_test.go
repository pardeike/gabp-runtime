package runtime

import "testing"

func TestMetadata(t *testing.T) {
	if ModulePath != "github.com/pardeike/gabp-runtime" {
		t.Fatalf("unexpected module path: %s", ModulePath)
	}

	if TargetGabpSchemaVersion != "1.0" {
		t.Fatalf("unexpected target schema version: %s", TargetGabpSchemaVersion)
	}
}
