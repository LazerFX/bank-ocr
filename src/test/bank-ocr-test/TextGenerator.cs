
namespace bank_ocr_test;

public class TextGenerator
{
    public static Dictionary<int, string> NumberData = new() {
        { 1, "   " + Environment.NewLine + "  |" + Environment.NewLine + "  |" },
        { 2, " _ " + Environment.NewLine + " _|" + Environment.NewLine + "|_ " }
    };

    internal static object CreateNumber(int input, string expectedOutput)
    {
        if (NumberData.TryGetValue(input, out var retval)) {
            return retval;
        }
        return "";
    }
}
