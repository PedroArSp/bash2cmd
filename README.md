# bash2cmd

A simple .NET 9 tool that converts multiline bash commands into Windows CMD-compatible commands.

Created mainly to help running **curl** commands on Windows — most API documentation and examples use bash syntax with `\` line continuations and single quotes, which don't work directly in CMD.

## What it does

1. Replaces `\` at end of line with `^` (CMD line continuation)
2. Replaces `"` with `\"` (escapes double quotes)
3. Replaces `'` with `"` (converts single quotes to double quotes)

## Usage

```
type input.txt | dotnet run
```

Or interactively: run `dotnet run`, paste your bash command, then press **Ctrl+Z** + **Enter** to process.

## Example

**Input (bash):**
```bash
curl -X POST \
  -H 'Content-Type: application/json' \
  -d '{"name": "test"}' \
  http://localhost:8080
```

**Output (CMD):**
```cmd
curl -X POST ^
  -H "Content-Type: application/json" ^
  -d "{\"name\": \"test\"}" ^
  http://localhost:8080
```

## Building locally

```
dotnet publish -c Release -r win-x64
```

The output will be at `bin/Release/net9.0/win-x64/publish/bash2cmd.exe` (~868 KB standalone, no .NET runtime needed).

## CI/CD - Automated Releases

This project uses GitHub Actions to automatically build and release the NativeAOT binary.

**How it works:**
- A push of a version tag (e.g., `v1.0.0`) triggers the workflow
- It builds the NativeAOT executable on Windows
- Creates a GitHub Release with the `bash2cmd.exe` attached

**To trigger a new release:**
```
git tag v1.0.0
git push origin v1.0.0
```

The release will appear at: https://github.com/PedroArSP/bash2cmd/releases

## Requirements

- .NET 9 SDK (for development/local build only)
- No runtime needed to run the published exe
