# gabp-runtime

Shared runtime layer for the Game Agent Bridge Protocol (GABP).

This repository is downstream from `GABP`. It does not define the protocol.
It packages reusable runtime code that speaks the canonical wire model already
defined in the `GABP` repo.

## Scope

`gabp-runtime` exists to hold the pieces that should be identical across
language implementations:

- wire DTOs
- error code constants
- serialization helpers
- request and response correlation primitives
- transport framing helpers where useful
- schema and conformance test harness wiring

It does not own:

- `Lib.GAB` server ergonomics, builders, or reflection-based tool discovery
- `GABS` MCP bridge logic, naming transforms, or process orchestration
- product-specific reconnect logic or session ownership

## Packages

The scaffold starts with two runtime package surfaces:

- NuGet package: `Gabp.Runtime`
- Go module: `github.com/pardeike/gabp-runtime`

Planned primary code entry points:

- C# namespace: `Gabp.Runtime`
- Go package path: `github.com/pardeike/gabp-runtime/runtime`

## Layout

```text
gabp-runtime/
  docs/
  dotnet/
    Gabp.Runtime/
    Gabp.Runtime.Tests/
  runtime/
  scripts/
  testdata/
    gabp/
      1.0/
        schemas/
        conformance/
```

## Source Of Truth

The protocol source of truth remains in `../GABP`.

This repo should consume:

- `GABP/SCHEMA/<version>`
- `GABP/CONFORMANCE/<version>`

The `testdata/` copies here are for runtime tests and local development, not for
owning protocol decisions.

## Current Status

This is a scaffold-only starting point.

What exists now:

- repo layout
- package names
- minimal .NET and Go package shells
- sync script for local schema and conformance fixtures

What does not exist yet:

- real message types
- serializers
- validators
- framing codec
- consumer integration in `Lib.GAB` or `GABS`

## Next Steps

1. Sync `testdata/` from `GABP`.
2. Add the common envelope, error, session, tool, event, resource, and state
   models.
3. Add serializer coverage in C# and Go.
4. Run both languages against the same `GABP` conformance fixtures.
