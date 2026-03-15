# Overview

`gabp-runtime` is the shared runtime layer that sits between the canonical
protocol repo (`GABP`) and language-specific products such as `Lib.GAB` and
`GABS`.

## Design Rules

- `GABP` remains the source of truth for protocol shapes and conformance.
- `gabp-runtime` packages reusable code, not protocol governance.
- Runtime packages should stay boring and low-level.
- Product-specific behaviors stay in the consumer repos.

## Package Names

- NuGet: `Gabp.Runtime`
- Go module: `github.com/pardeike/gabp-runtime`

## Planned Runtime Surface

- envelope/request/response/event types
- session welcome and hello models
- tool list and tool call models
- event subscription models
- resource and state models
- error codes and protocol constants
- JSON serialization and validation hooks
- optional `Content-Length` framing support

## Planned Non-Goals

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
