using DotNetA1Regex;
using static DotNetA1Regex.Utility;
using static DotNetA1Regex.AnsiColorCodes;

using System.Text.RegularExpressions;

namespace PatternTester
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Match a single character not present in the list below [^a-z]")]
        public void Test1()
        {
            Regex regexPattern = new("[^a-z]+/g");

            string actual = Utility.MatchPattern(regexPattern, "a");
            string expectedTrue = $"{GreenOnWhite} ✅ True {Reset}";
            string expectedFalse = $"{RedOnWhite} ❌ False {Reset}";
           
            Assert.Equal(expectedFalse, actual);
        }
    }
}
