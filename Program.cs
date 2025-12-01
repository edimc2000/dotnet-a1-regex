using System.Globalization;
using System.Text.RegularExpressions;

namespace DotNetA1Regex;

internal class Program
{
    private static void Main(string[] args)
    {
        //string defaultRegex = @"[a-z]+$";
        string defaultRegex = @"[a-z";
        //string defaultRegex = @"^\d";

        WriteLine("Enter a regular expression"); 
        Write("  or press ENTER to use the default)\t: ");
        string inputRegex = ReadLine()!;

        WriteLine();
        Write("Enter some input\t\t\t: ");
        string stringToMatch = ReadLine()!;

        inputRegex = inputRegex.Length == 0 ? defaultRegex : inputRegex;

    
        try
        {
            Regex patternChecker = new(inputRegex);
            WriteLine(
                $"{stringToMatch} matches {inputRegex} ? \t\t\t: {patternChecker.IsMatch(stringToMatch)}");
        }
        catch(Exception err)
        {
            WriteLine("There's and error with the regex pattern ");
            WriteLine(err.Message); 
        }

    }
}

// what is the default regex that we should use?