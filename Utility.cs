

using System.Diagnostics.Metrics;

namespace DotNetA1Regex;


internal class Utility
{
    internal static string divider = "\n  " + new string('-', 80) + "\n";
    internal static string indent = "".PadLeft(5); 

    internal static Dictionary<string, string> Input()
    {
        //WriteLine(divider);
        string defaultRegex = @"\d+";
        Dictionary<string, string> userInputs = new();

        WriteLine($"{indent}Enter a regular expression pattern");
        Write($"{indent}  (or press ENTER to use the default \"{defaultRegex}\")\t: ");
        string inputRegex = ReadLine()!.Trim();

        WriteLine(divider);
        Write($"{indent}Enter text to test against pattern\t\t\t: ");
        string stringToMatch = ReadLine()!.Trim();

        inputRegex = inputRegex.Length == 0 ? defaultRegex : inputRegex;

        userInputs.Add("defaultRegex", defaultRegex);
        userInputs.Add("inputRegex", inputRegex);
        userInputs.Add("stringToMatch", stringToMatch);

        return userInputs;
    }

    
    
    
}
