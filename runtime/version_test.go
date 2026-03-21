package runtime

import "testing"

func TestMetadata(t *testing.T) {
	if ModulePath != "github.com/pardeike/gabp-runtime" {
		t.Fatalf("unexpected module path: %s", ModulePath)
	}

	if Version != "1.0.0" {
		t.Fatalf("unexpected version: %s", Version)
	}

	if DevelopmentVersion != Version {
		t.Fatalf("unexpected compatibility alias: %s", DevelopmentVersion)
	}

	if TargetGabpSchemaVersion != "1.0" {
		t.Fatalf("unexpected target schema version: %s", TargetGabpSchemaVersion)
	}
}
