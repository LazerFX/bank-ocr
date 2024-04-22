
namespace bank_ocr_test;

public class TextGenerator
{
    private static Dictionary<int, string> NumberData = new() {
        { 1, "   " + Environment.NewLine + "  |" + Environment.NewLine + "  |" },
        { 2, " _ " + Environment.NewLine + " _|" + Environment.NewLine + "|_ " },
        { 3, " _ " + Environment.NewLine + " _|" + Environment.NewLine + " _|" },
        { 4, "   " + Environment.NewLine + "|_|" + Environment.NewLine + "  |" },
        { 5, " _ " + Environment.NewLine + "|_ " + Environment.NewLine + " _|" },
        { 6, " _ " + Environment.NewLine + "|_ " + Environment.NewLine + "|_|" },
        { 7, " _ " + Environment.NewLine + "  |" + Environment.NewLine + "  |" },
        { 8, " _ " + Environment.NewLine + "|_|" + Environment.NewLine + "|_|" },
        { 9, " _ " + Environment.NewLine + "|_|" + Environment.NewLine + " _|" },
    };

    internal static object CreateNumber(int input)
    {
        if (NumberData.TryGetValue(input, out var retval)) {
            return retval;
        }
        return "";
    }
}
