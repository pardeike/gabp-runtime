# Gabp.Runtime

Shared runtime primitives for the Game Agent Bridge Protocol (GABP).

This package is intentionally separate from the schema-only package in the
`GABP` repository. It is the place for reusable runtime code that both
`Lib.GAB` and `GABS` can build on.

## Planned Scope

- wire model types
- protocol constants and error codes
- serializer helpers
- request and response helpers
- optional framing helpers

## Out Of Scope

- server builders
- reflection-based tool registration
- MCP adaptation
- product-specific orchestration

## Current Status

Scaffold only. Real wire-model implementation has not been added yet.
