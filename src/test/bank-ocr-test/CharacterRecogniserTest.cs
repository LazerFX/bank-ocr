using System.Reflection.Metadata;
using bank_ocr;

namespace bank_ocr_test;

public class CharacterRecogniserTest
{
    public static string individiualZero =  " _ " + Environment.NewLine +
                                            "| |" + Environment.NewLine +
                                            "|_|" + Environment.NewLine;

    [Fact]
    public void GetCharacters_WillReturn_IndividualDigit() {
        var input = " _  _ " + Environment.NewLine +
                    "| || |" + Environment.NewLine +
                    "|_||_|" + Environment.NewLine;
        
        var expectedOutput = new[] { individiualZero, individiualZero };

        var actualOutput = CharacterRecogniser.GetCharacters(input);

        Assert.Equal(expectedOutput, actualOutput);
    }

    public static IEnumerable<object[]> SplitInto3s_Will_SplitStringIntoArrayOf3CharLongValues_Data() {
        yield return new object[] { "111222333", new string[] { "111", "222", "333" }};
        yield return new object[] { "111222333" + Environment.NewLine , new string[] { "111", "222", "333" }};
        yield return new object[] { "111222333444555666777888999" + Environment.NewLine , new string[] { "111", "222", "333", "444", "555", "666", "777", "888", "999" }};
        yield return new object[] { "111" + Environment.NewLine , new string[] { "111" }};
    }

    [Theory]
    [MemberData(nameof(SplitInto3s_Will_SplitStringIntoArrayOf3CharLongValues_Data))]
    public void SplitInto3s_Will_SplitStringIntoArrayOf3CharLongValues(string input, IEnumerable<string> expectedOutput) {
        var actualOutput = CharacterRecogniser.SplitInto3s(input);

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void GetDigit_Returns_ANumberForTheDigit() {
        var output = CharacterRecogniser.GetDigit(individiualZero);
        Assert.Equal(0, output);
    }
}
