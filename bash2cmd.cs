using System;
using System.Text;

// Show instructions if running interactively (not piped)
if (Console.IsInputRedirected == false)
{
    Console.Error.WriteLine("bash2cmd - Converts multiline bash commands to Windows CMD format.");
    Console.Error.WriteLine("Paste your bash command, then press Ctrl+Z (Windows) or Ctrl+D (Linux) to convert.");
    Console.Error.WriteLine();
}

// Read all input from stdin
var input = Console.In.ReadToEnd();
var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
var result = new StringBuilder();

for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i];

    // 1) Replace "\" at end of line by "^"
    if (line.EndsWith("\\"))
    {
        line = line.Substring(0, line.Length - 1) + "^";
    }

    // 2) Replace '"' by '\"'
    line = line.Replace("\"", "\\\"");

    // 3) Replace "'" by '"'
    line = line.Replace("'", "\"");

    result.AppendLine(line);
}

Console.Write(result.ToString());
