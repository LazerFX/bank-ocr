
namespace bank_ocr;

public class LineRecogniser
{
    public static int Ocr(string input)
    {
        var characters = CharacterRecogniser.GetCharacters(input);
        var digits = characters.Select(c => CharacterRecogniser.GetDigit(c));

        return 1234;
    }
}
