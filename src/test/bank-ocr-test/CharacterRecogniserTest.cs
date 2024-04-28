using bank_ocr;

namespace bank_ocr_test;

public class CharacterRecogniserTest
{
    [Fact]
    public void GetCharacters_WillReturn_IndividualDigit() {
        var input = " _  _ " + Environment.NewLine +
                    "| || |" + Environment.NewLine +
                    "|_||_|" + Environment.NewLine;
        
        var individiualZero = " _ " + Environment.NewLine +
                            "| |" + Environment.NewLine +
                            "|_|" + Environment.NewLine;
        
        var expectedOutput = new[] { individiualZero, individiualZero };

        var actualOutput = CharacterRecogniser.GetCharacters(input);

        Assert.Equal(expectedOutput, actualOutput);
    }
}
