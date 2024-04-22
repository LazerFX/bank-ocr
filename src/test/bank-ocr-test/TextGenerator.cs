
namespace bank_ocr_test;

using System.Linq;
using System.Text;

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

    internal static string CreateNumber(int input)
    {
        if (NumberData.TryGetValue(input, out var retval)) {
            return retval;
        }
        return "";
    }

    internal static string GetNumberString(int input) {
        var line1 = new StringBuilder();
        var line2 = new StringBuilder();
        var line3 = new StringBuilder();

        foreach (var digit in input.GetDigits()) {
            NumberData.TryGetValue(digit, out var raw);
            if (raw == null) {
                throw new ArgumentException("Expected a valid digit value", nameof(input));
            }

            var splitLines = raw.Split(Environment.NewLine);

            line1.Append(splitLines[0]);
            line2.Append(splitLines[1]);
            line3.Append(splitLines[2]);
        }

        var retVal = new StringBuilder();
        retVal.AppendJoin(Environment.NewLine, [line1.ToString(), line2.ToString(), line3.ToString()]);
        return retVal.ToString();
    }

    private static IEnumerable<int> GetDigits(this int value) =>
        value == 0 ? [] : GetDigits(value /  10).Append(value % 10);
}
