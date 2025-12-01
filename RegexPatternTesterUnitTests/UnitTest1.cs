using System.Text.RegularExpressions;
using static DotNetA1Regex.AnsiColorCodes; 
using static DotNetA1Regex.Utility; 

namespace RegexPatternTesterUnitTests
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Match a single character not present in the list below [^a-z]")]
        public void Test1()
        {
            Regex regexPattern = new("[^a-z]+/g");

            string actual = MatchPattern(regexPattern, "a");
            string expectedTrue = $"{GreenOnWhite} ✅ True {Reset}";
            string expectedFalse = $"{RedOnWhite} ❌ False {Reset}";

            Assert.Equal(expectedFalse, actual);
        }
    }
}
