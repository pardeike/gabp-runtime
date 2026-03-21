# Overview

`gabp-runtime` is the shared runtime layer that sits between the canonical
protocol repo (`GABP`) and language-specific products such as `Lib.GAB` and
`GABS`.

The runtime package uses its own semantic versioning. The first stable runtime
release is `v1.0.0`, while the current synced protocol assets come from the
additive `GABP v1.1.0` release and still target the `1.0` schema line.

## Design Rules

- `GABP` remains the source of truth for protocol shapes and conformance.
- `gabp-runtime` packages reusable code, not protocol governance.
- Runtime packages should stay boring and low-level.
- Product-specific behaviors stay in the consumer repos.

## Package Names

- NuGet: `Gabp.Runtime`
- Go module: `github.com/pardeike/gabp-runtime`

## Current Runtime Surface

- envelope/request/response/event types
- session welcome and hello models
- tool list and tool call models
- attention current and ack models
- shared attention payload models
- error codes and protocol constants
- JSON serialization helpers

## Remaining Scope

- event subscription models
- resource and state models
- JSON validation hooks
- optional `Content-Length` framing support

## Non-Goals

- reflection-based registration
- DI container opinions
- MCP naming transformations
- OpenAI naming transformations
- game launch or reconnect orchestration

## Test Data Strategy

The test fixtures in `testdata/gabp` should be copied from a pinned `GABP`
revision or release tag. Runtime tests should validate behavior against those
fixtures, but fixture contents should not be hand-edited here unless they are
purely local harness additions.
