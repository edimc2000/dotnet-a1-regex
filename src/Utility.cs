using System.Text.RegularExpressions;
using static DotNetA1Regex.AnsiColorCodes;

namespace DotNetA1Regex;

/// <summary>Utility class for regex pattern testing operations</summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 1.3</para>
/// <para>Since: 2025-12-01</para>
/// </remarks>
public class Utility
{
    private const int DividerWidth = 80;

    internal static readonly string SectionDivider = $"\n  {new string('-',
        DividerWidth)}\n";

    internal static string Indent = "".PadLeft(5);

    /// <summary>Prompts user for regex pattern and test text.</summary>
    /// <returns>Dictionary with keys: defaultPattern, pattern, inputText.</returns>
    internal static Dictionary<string, string> Input()
    {
        string defaultPattern = @"\d+";
        Dictionary<string, string> userInputs = new();

        WriteLine($"{Indent}Enter a regular expression pattern");
        Write($"{Indent}  (or press ENTER to use the default \"{defaultPattern}\")\t: ");
        string pattern = ReadLine()!.Trim();

        WriteLine(SectionDivider);
        Write($"{Indent}Enter text to test against pattern\t\t\t: ");
        string inputText = ReadLine()!.Trim();

        pattern = string.IsNullOrEmpty(pattern) ? defaultPattern : pattern;

        userInputs.Add("defaultPattern", defaultPattern);
        userInputs.Add("pattern", pattern);
        userInputs.Add("inputText", inputText);

        return userInputs;
    }

    /// <summary>Checks if regex pattern matches input text.</summary>
    /// <param name="regexPattern">Compiled regular expression.</param>
    /// <param name="inputText">Text to test against pattern.</param>
    /// <returns>Formatted success/failure indicator.</returns>
    public static string MatchPattern(Regex regexPattern, string inputText)
    {
        bool result = regexPattern.IsMatch(inputText);
        return result
            ? $"{GreenOnWhite} ✅ {result} {Reset}"
            : $"{RedOnWhite} ❌ {result} {Reset}";
    }

    /// <summary>Formats input text with color coding for display.</summary>
    /// <param name="inputText">Text to format.</param>
    /// <returns>Colored text or "empty" indicator.</returns>
    public static string EvaluateInputString(string inputText)
    {
        return !string.IsNullOrEmpty(inputText)
            ? $"{BlueOnWhite} {inputText} {Reset}"
            : $"{RedOnWhite} <empty> {Reset}";
    }
}