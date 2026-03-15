# GABP 1.0 Conformance Tests

This directory contains the copied GABP 1.0 conformance fixtures used by this
repo's Go and .NET tests.

These files are snapshots from the canonical `GABP` repo. They are local test
inputs, not the source of truth for protocol behavior.

## Test Categories

- **[valid/](valid/)** - six fixtures that should validate successfully
- **[invalid/](invalid/)** - six fixtures that should fail schema validation

## Purpose

- Provide one fixture set that both runtime implementations can consume.
- Keep copied protocol assets close to the code that round-trips them.
- Make it easy to spot when the local snapshot has drifted from `GABP`.

## Running Conformance Tests

From the repo root, validate all valid fixtures against the base envelope
schema:

```bash
ajv -s testdata/gabp/1.0/schemas/envelope.schema.json \
  -d 'testdata/gabp/1.0/conformance/valid/*.json'
```

Validate a fixture against its method-specific schema:

```bash
ajv -s testdata/gabp/1.0/schemas/methods/session.hello.request.json \
  -d testdata/gabp/1.0/conformance/valid/001_session_hello.json
```

Check that the invalid fixtures are rejected:

```bash
ajv -s testdata/gabp/1.0/schemas/envelope.schema.json \
  -d 'testdata/gabp/1.0/conformance/invalid/*.json' \
  --invalid
```

The `--invalid` flag tells AJV that validation failures are expected.

## Test Organization

- `valid/` currently covers `session/hello`, `session/welcome`, `tools/call`,
  `event`, error-response, and `tools/list` examples.
- `invalid/` currently covers missing IDs, conflicting `result` and `error`,
  invalid event shape, invalid method naming, wrong version, and invalid tool
  names.

## Adding New Tests

When adding conformance tests:
1. Include both positive and negative test cases
2. Sync them from `GABP` instead of hand-editing local copies when possible
3. Keep filenames stable enough for both language test suites to reference
