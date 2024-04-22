/*
    The Text Generator is utilised throughout the test framework for the `bank-ocr`.  It's going to take numerical input, and output it into textual strings.

    Each numerical character will have its own output.

    NOTE: Newlines should be never assumed to be either \r\n or \n only, always use `Environment.Newline`.  This sounds obvious, but writing out serves as
        an aide memoire and a deliberate statement of intent.
*/

namespace bank_ocr_test;

public class TextGeneratorTests
{
    public static IEnumerable<object[]> CreateNumber_DataSource() {
        yield return new object[] { 1, "   " + Environment.NewLine + "  |" + Environment.NewLine + "  |" };
    }

    [Theory]
    [MemberData(nameof(CreateNumber_DataSource))]
    public void CreateNumber_WillOutput_TheRightValue(int input, string expectedOutput)
    {
        var output = TextGenerator.CreateNumber(input, expectedOutput);
        output.Should().Be(expectedOutput);
    }
}