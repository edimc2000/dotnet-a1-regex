using System.Text.RegularExpressions;
using static DotNetA1Regex.AnsiColorCodes;
using static DotNetA1Regex.Utility;
using static DotNetA1Regex.Formatting;


bool tryAgain = true;
while (tryAgain)
{
    Clear();
    DisplayTitle("Regular Expression Tester", "all", 80);
    WriteLine();
    Dictionary<string, string> captureInput = Input();

    try
    {
        Regex patternChecker = new(captureInput["inputRegex"]);

        bool result = patternChecker.IsMatch(captureInput["stringToMatch"]);
        string displayResult = result
            ? $"{GreenOnWhite} ✅ {result} {Reset}"
            : $"{RedOnWhite} ❌ {result} {Reset}";

        string displayStringToMatch = captureInput["stringToMatch"].Length != 0
            ? $"{BlueOnWhite} {captureInput["stringToMatch"]} {Reset}"
            : $"{RedOnWhite} <empty> {Reset}";

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
        WriteLine($"{indent}There's and error with the regex pattern ");
        WriteLine($"{indent}{err.Message}");
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
