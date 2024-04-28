using bank_ocr;

namespace bank_ocr_test;

public class CharacterRecogniserTest
{
    [Fact]
    public void GetCharacters_WillReturn_IndividualDigit() {
        var input = " _  _ " + Environment.NewLine +
                    "| || |" + Environment.NewLine +
                    "|_||_|" + Environment.NewLine;
        
        var individiualZero =   " _ " + Environment.NewLine +
                                "| |" + Environment.NewLine +
                                "|_|" + Environment.NewLine;
        
        var expectedOutput = new[] { individiualZero, individiualZero };

        var actualOutput = CharacterRecogniser.GetCharacters(input);

        Assert.Equal(expectedOutput, actualOutput);
    }

    public static IEnumerable<object[]> SplitInto3s_Will_SplitStringIntoArrayOf3CharLongValues_Data() {
        yield return new object[] { "111222333", new string[] { "111", "222", "333" }};
    }

    [Fact]
    public void SplitInto3s_Will_SplitStringIntoArrayOf3CharLongValues() {
        var input = "111222333";
        IEnumerable<string> expectedOutput = ["111", "222", "333"];

        var actualOutput = CharacterRecogniser.SplitInto3s(input);

        Assert.Equal(expectedOutput, actualOutput);
    }
}
