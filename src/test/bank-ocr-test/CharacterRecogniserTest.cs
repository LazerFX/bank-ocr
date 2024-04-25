using bank_ocr;

namespace bank_ocr_test;

public class CharacterRecogniserTest
{
    [Fact]
    public void GetCharacters_WillReturn_SplitUpDigits() {
        var input = " _ " + Environment.NewLine +
                    "| |" + Environment.NewLine +
                    "|_|" + Environment.NewLine;
        var expectedOutput = new[] { 0 };

        var actualOutput = CharacterRecogniser.GetCharacters(input);

        Assert.Equal(expectedOutput, actualOutput);
    }
}
