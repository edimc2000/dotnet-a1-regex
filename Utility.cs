namespace DotNetA1Regex;

internal class Utility
{
    internal static string divider = "\n" + new string('-', 80) + "\n";

    internal static Dictionary<string, string> Input()
    {
        WriteLine(divider);
        string defaultRegex = @"\d+";
        Dictionary<string, string> userInputs = new();

        WriteLine("Enter a regular expression");
        Write("  (or press ENTER to use the default)\t: ");
        string inputRegex = ReadLine()!.Trim();

        WriteLine(divider);
        Write("Enter some input\t\t\t: ");
        string stringToMatch = ReadLine()!.Trim();

        inputRegex = inputRegex.Length == 0 ? defaultRegex : inputRegex;

        userInputs.Add("defaultRegex", defaultRegex);
        userInputs.Add("inputRegex", inputRegex);
        userInputs.Add("stringToMatch", stringToMatch);

        return userInputs;
    }
}
