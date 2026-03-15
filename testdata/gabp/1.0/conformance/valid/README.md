# Valid Conformance Test Cases

This directory contains the positive GABP fixtures currently consumed by the Go
and .NET runtime tests in this repository.

These six files are representative samples, not full coverage of every schema
present under `../../schemas/`.

## Current Fixture Set

- `001_session_hello.json` - request fixture for `session/hello`
- `002_session_welcome.json` - success response fixture for `session/welcome`
- `003_tools_call.json` - request fixture for `tools/call`
- `004_event_message.json` - generic event envelope fixture
- `005_error_response.json` - response fixture carrying a protocol error
- `006_tools_list_response.json` - success response fixture for `tools/list`

## Message Validation

All messages in this directory should:
- Pass validation against `../../schemas/envelope.schema.json`
- Pass validation against their specific method schemas
- Demonstrate correct GABP protocol usage

## Running Tests

Validate all messages in this directory:

```bash
ajv -s ../../schemas/envelope.schema.json -d '*.json'

# Method-specific validation examples
ajv -s ../../schemas/methods/session.hello.request.json -d 001_session_hello.json
ajv -s ../../schemas/methods/tools.list.response.json -d 006_tools_list_response.json
```

## Expected Behavior

When an implementation encounters messages like these:
- **Parsing** should succeed without errors
- **Schema validation** should pass
- **Protocol handling** should process the message appropriately
- **Responses** should be generated as specified in the protocol

In this repo, those expectations are currently exercised by fixture round-trip
tests for the session, tool, event, and error message shapes listed above.
