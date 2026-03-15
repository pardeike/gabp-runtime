#!/usr/bin/env sh

set -eu

script_dir=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
repo_root=$(CDPATH= cd -- "$script_dir/.." && pwd)
gabp_dir="${GABP_DIR:-$repo_root/../GABP}"

schema_src="$gabp_dir/SCHEMA/1.0"
conformance_src="$gabp_dir/CONFORMANCE/1.0"
schema_dst="$repo_root/testdata/gabp/1.0/schemas"
conformance_dst="$repo_root/testdata/gabp/1.0/conformance"

test -d "$schema_src"
test -d "$conformance_src"

rm -rf "$schema_dst" "$conformance_dst"
mkdir -p "$schema_dst" "$conformance_dst"

cp -R "$schema_src"/. "$schema_dst"/
cp -R "$conformance_src"/. "$conformance_dst"/

printf 'Synced %s -> %s\n' "$schema_src" "$schema_dst"
printf 'Synced %s -> %s\n' "$conformance_src" "$conformance_dst"
