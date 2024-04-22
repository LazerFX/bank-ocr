
namespace bank_ocr_test;

using System.Linq;

public static class TextGenerator
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

    internal static object GetNumberString(int input) =>
        input.GetDigits().Select(x => NumberData[x]);

    private static IEnumerable<int> GetDigits(this int value) =>
        value == 0 ? [] : GetDigits(value /  10).Append(value % 10);
}
