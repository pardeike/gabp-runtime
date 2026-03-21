# Changelog

All notable changes to `gabp-runtime` will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/).

## 1.0.0 - 2026-03-21

### Added

- First stable `gabp-runtime` release for the shared Go and .NET runtime layer.
- Shared attention DTOs and protocol constants for `attention/current`,
  `attention/ack`, and attention event payloads.

### Changed

- Synced `testdata/gabp/1.0` from the additive `GABP v1.1.0` release,
  including the new attention schemas and conformance fixtures.
- Replaced stale prerelease metadata and documentation with stable `1.0.0`
  package versioning.
- Updated release-facing documentation to clarify that runtime package
  versioning is independent from `GABP` repository release numbers.
