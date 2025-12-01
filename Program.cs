using System.Text.RegularExpressions;
using static DotNetA1Regex.AnsiColorCodes;
using static DotNetA1Regex.Utility;
using static DotNetA1Regex.Formatting;


const bool tryAgain = true;
while (tryAgain)
{
    Clear();
    //WriteLine(args[0]);
    DisplayTitle("Regular Expression Tester", "all", 80);
    WriteLine();
    Dictionary<string, string> captureInput = Input();

    try
    {
        Regex patternChecker = new(captureInput["inputRegex"]);
        string displayResult = MatchPattern(patternChecker, captureInput["stringToMatch"]);
        string displayStringToMatch = EvaluateInputString(captureInput["stringToMatch"]); 

        WriteLine();
        DisplayTitle("", "top", 80);
        WriteLine(PrintCenteredTitle("Result", 80));
        DisplayTitle("", "bottom", 80);

        WriteLine($"\n{indent}Pattern\t: {BlueOnWhite} {captureInput["inputRegex"]} {Reset}");
        WriteLine($"{indent}Input\t: {displayStringToMatch}");
        WriteLine($"\n{indent}Match\t: {displayResult}");
    }
    catch (Exception err)
    {
        WriteLine($"\n{indent}{HighlightError} There's an error with the regex pattern {Reset}");
        WriteLine($"{indent}{HighlightError} {err.Message} {Reset}");
    }

    WriteLine(divider);
    Write($"{indent}Press ESC to end or any key to try again\t\t: ");
    ConsoleKeyInfo key = ReadKey(true);

    if (key.Key == ConsoleKey.Escape)
    {
        WriteLine($"\n{indent}Operation cancelled!\n\n");
        return; // or break
    }
}
