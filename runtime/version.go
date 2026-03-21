package runtime

const (
	// ModulePath is the canonical Go module path for this repository.
	ModulePath = "github.com/pardeike/gabp-runtime"

	// PackagePath is the primary Go package path for the runtime layer.
	PackagePath = ModulePath + "/runtime"

	// Version is the current gabp-runtime package version.
	Version = "1.0.0"

	// DevelopmentVersion is retained as a compatibility alias for Version.
	DevelopmentVersion = Version

	// TargetGabpSchemaVersion is the GABP schema line this repo targets.
	TargetGabpSchemaVersion = "1.0"
)
