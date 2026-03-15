# Method Schemas

This directory contains the copied GABP 1.0 method schemas. Each method has
separate request and response schemas where the protocol defines both.

The schema snapshot is ahead of the typed runtime surface in this repo. The Go
and .NET packages currently provide dedicated DTOs for `session/hello`,
`session/welcome`, `tools/call`, and `tools/list`; the remaining method schemas
are present here for shared fixtures and future expansion.

## Core Methods

### Session Management
- **[session.hello.request.json](session.hello.request.json)** - Initial handshake from bridge
- **[session.welcome.response.json](session.welcome.response.json)** - Handshake response from mod

### Tool Operations
- **[tools.list.request.json](tools.list.request.json)** - Request available tools
- **[tools.list.response.json](tools.list.response.json)** - List of tool definitions
- **[tools.call.request.json](tools.call.request.json)** - Invoke a specific tool
- **[tools.call.response.json](tools.call.response.json)** - Tool execution result

### Event Management
- **[events.subscribe.request.json](events.subscribe.request.json)** - Subscribe to event channels
- **[events.unsubscribe.request.json](events.unsubscribe.request.json)** - Unsubscribe from channels

### Resource Access
- **[resources.list.request.json](resources.list.request.json)** - List available resources
- **[resources.list.response.json](resources.list.response.json)** - Resource directory listing
- **[resources.read.request.json](resources.read.request.json)** - Read resource content
- **[resources.read.response.json](resources.read.response.json)** - Resource data

### State Management
- **[state.get.request.json](state.get.request.json)** - Retrieve state components
- **[state.get.response.json](state.get.response.json)** - Current state values
- **[state.set.request.json](state.set.request.json)** - Update state components
- **[state.set.response.json](state.set.response.json)** - State update confirmation

## Schema Structure

Each method schema:
- Extends the base envelope schema
- Defines method-specific parameters/results
- Includes validation rules for required fields
- Specifies allowed data types and formats

## Usage

Validate method-specific messages:
```bash
# Validate a tools/list request
ajv -s tools.list.request.json -d 'example-tools-list.json'

# Validate a session/hello request  
ajv -s session.hello.request.json -d 'example-hello.json'
```

## Custom Methods

When implementing custom methods, follow these patterns:
- Use the envelope structure as a base
- Follow the canonical naming rules from the `GABP` source repo rather than
  inventing local conventions here
- Include proper validation for all parameters
- Define clear input and output schemas
