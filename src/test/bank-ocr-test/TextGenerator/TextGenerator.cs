﻿
namespace bank_ocr_test.TextGenerator;

using System.Linq;
using System.Text;

public static class TextGenerator
{
    private static Dictionary<int, string> NumberData = new() {
        { 0, " _ " + Environment.NewLine + "| |" + Environment.NewLine + "|_|" },
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
        if (NumberData.TryGetValue(input, out var retval))
        {
            return retval;
        }
        return "";
    }

    internal static string GetNumberString(int input)
    {
        var line1 = new StringBuilder();
        var line2 = new StringBuilder();
        var line3 = new StringBuilder();
        
        var numberArray = GetPaddedNumberArray(input);

        foreach (var digit in numberArray)
        {
            NumberData.TryGetValue(digit, out var raw);
            if (raw == null) { return ""; }

            var splitLines = raw.Split(Environment.NewLine);

            line1.Append(splitLines[0]);
            line2.Append(splitLines[1]);
            line3.Append(splitLines[2]);
        }

        return CreateMultiLine(line1, line2, line3);
    }

    private static string CreateMultiLine(params StringBuilder[] lines) {
        var returnValue = new StringBuilder();
        foreach (var line in lines) {
            returnValue.Append(line).AppendLine();
        }
        return returnValue.ToString();
    }

    private static IEnumerable<int> GetPaddedNumberArray(int input)
    {
        var numberArray = input.GetDigits();

        while (numberArray.Count() < 9)
        {
            numberArray = numberArray.Prepend(0);
        }

        return numberArray;
    }

    private static IEnumerable<int> GetDigits(this int value) =>
        value == 0 ? [] : (value / 10).GetDigits().Append(value % 10);
}
