
namespace bank_ocr;

public static class CharacterRecogniser
{
    public static IEnumerable<string> GetCharacters(string digits)
    {
        var inputLines = digits.Split(Environment.NewLine);
        var output = new List<string>();
        var splitLine1 = inputLines[0].SplitInto3s();

        return [];
    }

    public static IEnumerable<string> SplitInto3s(this string input) {
        throw new NotImplementedException();
    }
}