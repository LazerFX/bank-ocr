/*
    The Text Generator is utilised throughout the test framework for the `bank-ocr`.  It's going to take numerical input, and output it into textual strings.

    Each numerical character will have its own output.

    NOTE: Newlines should be never assumed to be either \r\n or \n only, always use `Environment.Newline`.  This sounds obvious, but writing out serves as
        an aide memoire and a deliberate statement of intent.
    
    NOTE: If you're using a ligatured font, such as FiraCode, the demonstration glyphs may seem a little odd, as two pipes `||` is ligatured into a single 
        glyph.
*/

namespace bank_ocr_test;

public class TextGeneratorTests
{
    public static IEnumerable<object[]> CreateNumber_DataSource() {
        yield return new object[] { 0,  " _ " + Environment.NewLine + 
                                        "| |" + Environment.NewLine + 
                                        "|_|" };
        yield return new object[] { 1,  "   " + Environment.NewLine + 
                                        "  |" + Environment.NewLine + 
                                        "  |" };
        yield return new object[] { 2,  " _ " + Environment.NewLine + 
                                        " _|" + Environment.NewLine + 
                                        "|_ " };
        yield return new object[] { 3,  " _ " + Environment.NewLine + 
                                        " _|" + Environment.NewLine + 
                                        " _|" };
        yield return new object[] { 4,  "   " + Environment.NewLine + 
                                        "|_|" + Environment.NewLine + 
                                        "  |" };
        yield return new object[] { 5,  " _ " + Environment.NewLine + 
                                        "|_ " + Environment.NewLine + 
                                        " _|" };
        yield return new object[] { 6,  " _ " + Environment.NewLine + 
                                        "|_ " + Environment.NewLine + 
                                        "|_|" };
        yield return new object[] { 7,  " _ " + Environment.NewLine + 
                                        "  |" + Environment.NewLine + 
                                        "  |" };
        yield return new object[] { 8,  " _ " + Environment.NewLine + 
                                        "|_|" + Environment.NewLine + 
                                        "|_|" };
        yield return new object[] { 9,  " _ " + Environment.NewLine + 
                                        "|_|" + Environment.NewLine + 
                                        " _|" };
    }

    [Theory]
    [MemberData(nameof(CreateNumber_DataSource))]
    public void CreateNumber_WillOutput_TheRightValue(int input, string expectedOutput)
    {
        var output = TextGenerator.CreateNumber(input);
        output.Should().Be(expectedOutput);
    }

    public static IEnumerable<object[]> GetNumberString_DataSource() {
        yield return new object[] { 123456789,  "    _  _     _  _  _  _  _ " + Environment.NewLine +
                                                "  | _| _||_||_ |_   ||_||_|" + Environment.NewLine +
                                                "  ||_  _|  | _||_|  ||_| _|"};
    }

    [Theory]
    [MemberData(nameof(GetNumberString_DataSource))]
    public void GetNumberString_WillOutput_TheRightValue(int input, string expectedOutput) {
        var output = TextGenerator.GetNumberString(input);
        output.Should().Be(expectedOutput);
    }
}