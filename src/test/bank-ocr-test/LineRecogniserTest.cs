using bank_ocr;
using bank_ocr_test.TextGenerator;

namespace bank_ocr_test;

public class LineRecogniserTest
{
    [Fact]
    public void LineRecogniser_Should_OutputTheRightDigits() {
        var digits = TextGenerator.TextGenerator.CreateNumber(1234);
        var output = LineRecogniser.Ocr(digits);
        output.Should().Be(1234);
    }
}
