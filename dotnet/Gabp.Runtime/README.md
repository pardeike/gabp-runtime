# Gabp.Runtime

Shared runtime primitives for the Game Agent Bridge Protocol (GABP).

This package is intentionally separate from the schema-only package in the
`GABP` repository. It is the place for reusable runtime code that both
`Lib.GAB` and `GABS` can build on.

## Current Surface

- generic request, response, and event envelopes
- `GabpProtocol`, `RuntimeMetadata`, and `GabpError`
- `GabpJson` serialization helpers
- session handshake models for `session/hello` and `session/welcome`
- capabilities and limits models
- tool descriptor, `tools/call`, and `tools/list` models

## Out Of Scope

- server builders
- reflection-based tool registration
- MCP adaptation
- product-specific orchestration
- schema authoring and protocol governance

## Not Included Yet

- dedicated resource, state, or event subscription DTOs
- JSON Schema validation
- transport framing helpers
