using System.Text.RegularExpressions;
using static DotNetA1Regex.AnsiColorCodes;
using static DotNetA1Regex.Utility;
using static DotNetA1Regex.Formatting;

namespace DotNetA1Regex;

/// <summary>Main entry point for the Regex Tester application</summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 2.0</para>
/// <para>Since: 2025-12-02</para>
/// </remarks>
public class Program
{
    public static void Main(string[] args)
    {

        bool shouldContinue = true;
        const int ConsoleWidth = 80;
        const string PatternKey = "pattern";
        const string InputTextKey = "inputText";

        while (shouldContinue)
        {
            Clear();
            DisplayTitle("Regular Expression Tester", "all", ConsoleWidth);
            WriteLine();
            Dictionary<string, string> userInput = Input();

            try
            {
                Regex regexPattern = new(userInput[PatternKey]);
                string matchResult = MatchPattern(regexPattern, userInput[InputTextKey]);
                string formattedInput = EvaluateInputString(userInput[InputTextKey]);

                WriteLine();
                DisplayTitle("", "top", ConsoleWidth);
                WriteLine(PrintCenteredTitle("Result", ConsoleWidth));
                DisplayTitle("", "bottom", ConsoleWidth);

                WriteLine($"\n{Indent}Pattern\t\t: {BlueOnWhite} {userInput[PatternKey]} {Reset}");
                WriteLine($"{Indent}Input Text\t\t: {formattedInput}");
                WriteLine($"\n{Indent}Match\t\t: {matchResult}");
            }
            catch (Exception err)
            {
                WriteLine($"\n{Indent}{HighlightError} Error: {err.Message} {Reset}");
            }

            WriteLine(SectionDivider);
            Write($"{Indent}Press ESC to exit or any key to continue\t: ");
            ConsoleKeyInfo key = ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                WriteLine($"\n{Indent}Goodbye!\n");
                shouldContinue = false;
            }
        }

        //WriteLine(args[0]); // For future command line support
    }
}