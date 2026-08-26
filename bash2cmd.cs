using System;
using System.Text;

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
