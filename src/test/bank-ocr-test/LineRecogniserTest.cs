using bank_ocr;
using bank_ocr_test.TextGenerator;

namespace bank_ocr_test;

public class LineRecogniserTest
{
    public static IEnumerable<object[]> LineRecogniser_Data() {
        yield return new object[] { TextGenerator.TextGenerator.CreateNumber(1234), 1234 };
        yield return new object[] { TextGenerator.TextGenerator.CreateNumber(490067715), 490067715 };
        yield return new object[] { TextGenerator.TextGenerator.CreateNumber(012345678), 012345678 };
        yield return new object[] { TextGenerator.TextGenerator.CreateNumber(098765432), 098765432 };
        yield return new object[] { TextGenerator.TextGenerator.CreateNumber(102938475), 102938475 };
    }

    [Theory]
    [MemberData(nameof(LineRecogniser_Data))]
    public void LineRecogniser_Should_OutputTheRightDigits(string input, int expectedOcr) {
        var output = LineRecogniser.Ocr(input);

        output.Should().Be(expectedOcr);
    }
}
