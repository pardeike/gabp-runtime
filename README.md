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

## Package Surfaces

This repo currently exposes two language surfaces:

- .NET project/package id: `Gabp.Runtime`
- Go module: `github.com/pardeike/gabp-runtime`

Primary code entry points:

- C# namespace: `Gabp.Runtime`
- Go package path: `github.com/pardeike/gabp-runtime/runtime`

Install the published packages with:

```bash
dotnet add package Gabp.Runtime --prerelease
go get github.com/pardeike/gabp-runtime@v0.1.0-alpha.1
```

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

The repo is no longer scaffold-only. The shared runtime surface implemented
today includes:

- generic request, response, and event envelopes
- protocol constants and runtime metadata
- error object models
- JSON serialization helpers in Go and .NET
- session handshake DTOs for `session/hello` and `session/welcome`
- capability and limit models
- tool DTOs for `tools/call` and `tools/list`
- shared conformance fixtures exercised by Go and .NET tests

The runtime packages do not yet include:

- dedicated DTOs for `events.subscribe`, `events.unsubscribe`, `resources.*`,
  or `state.*`
- schema validation or generated validators
- transport framing helpers
- consumer integration in `Lib.GAB` or `GABS`

## Next Steps

1. Keep `testdata/` synchronized from `GABP`.
2. Extend the typed runtime surface to the remaining copied method schemas.
3. Add validation and framing only if the consumer repos need them here.
4. Continue exercising both language implementations against the same fixture
   set.
