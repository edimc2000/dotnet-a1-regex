using System.Text.RegularExpressions;
using static DotNetA1Regex.AnsiColorCodes;
using static DotNetA1Regex.Utility;

namespace DotNetA1Regex;

internal class Program
{
    private static void Main(string[] args)
    {
        bool tryAgain = true;
        while (tryAgain)
        {
            //Clear();
            Dictionary<string, string> captureInput = Input();
            WriteLine(divider);
            try
            {
                Regex patternChecker = new(captureInput["inputRegex"]);

                bool result = patternChecker.IsMatch(captureInput["stringToMatch"]);
                string displayResult = result
                    ? $"{GreenOnWhite} {result} {Reset}"
                    : $"{RedOnWhite} {result} {Reset}";

               
                WriteLine(
                    $"\n{BlueOnWhite} {captureInput["stringToMatch"]} {Reset} matches " +
                    $"{BlueOnWhite} {captureInput["inputRegex"]} {Reset} ?:" +
                    $"{displayResult}");
            }
            catch (Exception err)
            {
                WriteLine("There's and error with the regex pattern ");
                WriteLine(err.Message);
            }

            WriteLine(divider);
            Write("Press ESC to end or any key to try again: ");
            ConsoleKeyInfo key = ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                WriteLine("\nOperation cancelled!");
                return; // or break
            }
        }
    }
}