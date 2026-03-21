# Gabp.Runtime

Shared runtime primitives for the Game Agent Bridge Protocol (GABP).

This package is intentionally separate from the schema-only package in the
`GABP` repository. It is the place for reusable runtime code that both
`Lib.GAB` and `GABS` can build on.

This package follows its own runtime versioning. `Gabp.Runtime v1.0.0` is the
first stable runtime release and targets the `GABP` schema line `1.0`.

## Installation

```bash
dotnet add package Gabp.Runtime
```

## Current Surface

- generic request, response, and event envelopes
- `GabpProtocol`, `RuntimeMetadata`, and `GabpError`
- `GabpJson` serialization helpers
- session handshake models for `session/hello` and `session/welcome`
- capabilities and limits models
- tool descriptor, `tools/call`, and `tools/list` models
- attention summary, `attention/current`, and `attention/ack` models

## Out Of Scope

- server builders
- reflection-based tool registration
- MCP adaptation
- product-specific orchestration
- schema authoring and protocol governance

## Remaining Scope

- dedicated resource, state, or event subscription DTOs
- JSON Schema validation
- transport framing helpers
