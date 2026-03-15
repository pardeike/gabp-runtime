# Invalid Conformance Test Cases

This directory contains the negative GABP fixtures copied into this repo. Each
file should fail schema validation.

The runtime packages in this repository do not currently ship a validator, so
these files are primarily for shared schema-driven harnesses and higher-level
consumer tests.

## Current Fixture Set

- `001_missing_id.json` - request envelope missing `id`
- `002_both_result_and_error.json` - response includes both `result` and `error`
- `003_event_with_method.json` - event envelope incorrectly includes `method`
- `004_invalid_method_pattern.json` - request uses an invalid method name
- `005_wrong_version.json` - request uses `gabp/2` instead of `gabp/1`
- `006_invalid_tool_name.json` - tool name violates the schema pattern

## Expected Behavior

A schema-aware implementation or harness should reject these files without
crashing. The exact error reporting behavior belongs in higher-level consumers,
not in this low-level runtime package.

## Validation Testing

Test that these messages fail validation as expected:

```bash
ajv -s ../../schemas/envelope.schema.json -d '*.json' --invalid
```

The `--invalid` flag tells AJV that validation failures are expected and desired.

If you need per-schema checks, point AJV at the specific method schema for the
fixture you are exercising.
