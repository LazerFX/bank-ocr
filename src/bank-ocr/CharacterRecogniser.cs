
namespace bank_ocr;

public static class CharacterRecogniser
{
    public static IEnumerable<string> GetCharacters(string digits)
    {
        var inputLines = digits.Split(Environment.NewLine);
        var splitLine1 = inputLines[0].SplitInto3s();
        var splitLine2 = inputLines[1].SplitInto3s();
        var splitline3 = inputLines[2].SplitInto3s();

        foreach ((string line1, string line2, string line3) in splitLine1.Zip(splitLine2, splitline3)) {
            yield return    line1 + Environment.NewLine +
                            line2 + Environment.NewLine +
                            line3 + Environment.NewLine;
        }
    }

    public static IEnumerable<string> SplitInto3s(this string input) =>
        Enumerable.Range(0, input.Length / 3)
            .Select(i => input.Substring(i * 3, 3));

    public static int GetDigit(string character)
    {
        return 0;
    }
}