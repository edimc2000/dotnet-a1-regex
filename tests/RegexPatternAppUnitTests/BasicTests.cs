using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;
using static DotNetA1Regex.AnsiColorCodes;
using static DotNetA1Regex.Utility;

namespace RegexPatternAppUnitTests;

public class BasicTests

{
    private readonly ITestOutputHelper _output;

    public BasicTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact(DisplayName = "Match a single character not present in the list below [^a-z]")]
    public void Test1()
    {
        string stringPattern = "[^a-z]+/g";
        Regex regexPattern = new(stringPattern);
        string actual = MatchPattern(regexPattern, "a");
        string expectedTrue = $"{GreenOnWhite} ✅ True {Reset}";
        string expectedFalse = $"{RedOnWhite} ❌ False {Reset}";

        for (char c = 'a'; c <= 'z'; c++)
        {
            actual = MatchPattern(regexPattern, c.ToString());
            _output.WriteLine($"TEST: regex pattern: {stringPattern} with input \"{c}\" ");
            Assert.Equal(expectedFalse, actual);
        }
    }

    [Fact(DisplayName = "Match only lowercase letters [a-z]")]
    public void Test2_LowercaseLettersOnly()
    {
        string stringPattern = "^[a-z]+$";
        Regex regexPattern = new(stringPattern);
        string expectedTrue = $"{GreenOnWhite} ✅ True {Reset}";
        string expectedFalse = $"{RedOnWhite} ❌ False {Reset}";

        // Test lowercase letters should pass
        for (char c = 'a'; c <= 'z'; c++)
        {
            string actual = MatchPattern(regexPattern, c.ToString());
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{c}'");
            Assert.Equal(expectedTrue, actual);
        }

        // Test uppercase letters should fail
        for (char c = 'A'; c <= 'Z'; c++)
        {
            string actual = MatchPattern(regexPattern, c.ToString());
            _output.WriteLine($"NEGA TEST: pattern '{stringPattern}' with input '{c}'");
            Assert.Equal(expectedFalse, actual);
        }
    }

    [Fact(DisplayName = "Match digits only [0-9]")]
    public void Test3_DigitsOnly()
    {
        string stringPattern = @"^\d+$";
        Regex regexPattern = new(stringPattern);
        string expectedTrue = $"{GreenOnWhite} ✅ True {Reset}";
        string expectedFalse = $"{RedOnWhite} ❌ False {Reset}";

        // Test digits 0-9 should pass
        for (int i = 0; i <= 9; i++)
        {
            var actual = MatchPattern(regexPattern, i.ToString());
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{i}'");
            Assert.Equal(expectedTrue, actual);
        }

        // Test letters should fail
        for (char c = 'a'; c <= 'f'; c++) // Just test a few
        {
            var actual = MatchPattern(regexPattern, c.ToString());
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{c}'");
            Assert.Equal(expectedFalse, actual);
        }
    }

    [Fact(DisplayName = "Match uppercase letters [A-Z]")]
    public void Test4_UppercaseLettersOnly()
    {
        string stringPattern = "^[A-Z]+$";
        Regex regexPattern = new(stringPattern);
        string expectedTrue = $"{GreenOnWhite} ✅ True {Reset}";
        string expectedFalse = $"{RedOnWhite} ❌ False {Reset}";

        // Test uppercase letters should pass
        for (char c = 'A'; c <= 'Z'; c++)
        {
            var actual = MatchPattern(regexPattern, c.ToString());
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{c}'");
            Assert.Equal(expectedTrue, actual);
        }

        // Test lowercase letters should fail
        for (char c = 'a'; c <= 'z'; c++)
        {
            var actual = MatchPattern(regexPattern, c.ToString());
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{c}'");
            Assert.Equal(expectedFalse, actual);
        }
    }

    [Fact(DisplayName = "Match alphanumeric characters [a-zA-Z0-9]")]
    public void Test5_AlphanumericOnly()
    {
        string stringPattern = "^[a-zA-Z0-9]+$";
        Regex regexPattern = new(stringPattern);
        string expectedTrue = $"{GreenOnWhite} ✅ True {Reset}";
        string expectedFalse = $"{RedOnWhite} ❌ False {Reset}";

        // Test alphanumeric should pass
        var testCases = new List<string>();
    
        // Add letters
        for (char c = 'a'; c <= 'z'; c++) testCases.Add(c.ToString());
        for (char c = 'A'; c <= 'Z'; c++) testCases.Add(c.ToString());
    
        // Add digits
        for (int i = 0; i <= 9; i++) testCases.Add(i.ToString());

        foreach (var test in testCases)
        {
            var actual = MatchPattern(regexPattern, test);
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{test}'");
            Assert.Equal(expectedTrue, actual);
        }

        // Test special characters should fail
        var specialChars = new[] { "@", "#", "$", "%", "&", "*", "(", ")", "-", "_", "+", "=" };
        foreach (var special in specialChars)
        {
            var actual = MatchPattern(regexPattern, special);
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{special}'");
            Assert.Equal(expectedFalse, actual);
        }
    }

    [Fact(DisplayName = "Match word characters (letters, digits, underscore)")]
    public void Test6_WordCharactersOnly()
    {
        string stringPattern = @"^\w+$";
        Regex regexPattern = new(stringPattern);
        string expectedTrue = $"{GreenOnWhite} ✅ True {Reset}";
        string expectedFalse = $"{RedOnWhite} ❌ False {Reset}";

        // Test word characters should pass
        var passingCases = new List<string>();
    
        // Letters
        for (char c = 'a'; c <= 'z'; c++) passingCases.Add(c.ToString());
        for (char c = 'A'; c <= 'Z'; c++) passingCases.Add(c.ToString());
    
        // Digits
        for (int i = 0; i <= 9; i++) passingCases.Add(i.ToString());
    
        // Underscore
        passingCases.Add("_");

        foreach (var test in passingCases)
        {
            var actual = MatchPattern(regexPattern, test);
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{test}'");
            Assert.Equal(expectedTrue, actual);
        }

        // Test non-word characters should fail
        var failingCases = new[] { "@", "#", "$", " ", ".", ",", ";", ":" };
        foreach (var test in failingCases)
        {
            var actual = MatchPattern(regexPattern, test);
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{test}'");
            Assert.Equal(expectedFalse, actual);
        }
    }

    [Fact(DisplayName = "Match hexadecimal characters [0-9a-fA-F]")]
    public void Test7_HexadecimalCharacters()
    {
        string stringPattern = "^[0-9a-fA-F]+$";
        Regex regexPattern = new(stringPattern);
        string expectedTrue = $"{GreenOnWhite} ✅ True {Reset}";
        string expectedFalse = $"{RedOnWhite} ❌ False {Reset}";

        // Test hexadecimal characters should pass
        var hexChars = new List<string>();
    
        // Digits
        for (int i = 0; i <= 9; i++) hexChars.Add(i.ToString());
    
        // Lowercase hex letters
        for (char c = 'a'; c <= 'f'; c++) hexChars.Add(c.ToString());
    
        // Uppercase hex letters
        for (char c = 'A'; c <= 'F'; c++) hexChars.Add(c.ToString());

        foreach (var ch in hexChars)
        {
            var actual = MatchPattern(regexPattern, ch);
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{ch}'");
            Assert.Equal(expectedTrue, actual);
        }

        // Test non-hex characters should fail
        var nonHexChars = new[] { "g", "G", "z", "Z", "@", "#" };
        foreach (var ch in nonHexChars)
        {
            var actual = MatchPattern(regexPattern, ch);
            _output.WriteLine($"TEST: pattern '{stringPattern}' with input '{ch}'");
            Assert.Equal(expectedFalse, actual);
        }
    }

}