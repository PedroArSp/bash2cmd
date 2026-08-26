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

## Requirements

- .NET 9 SDK
