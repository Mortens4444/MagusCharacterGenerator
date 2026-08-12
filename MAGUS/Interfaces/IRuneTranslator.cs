namespace MAGUS.Interfaces;

public interface IRuneTranslator
{
    string ToRunes(string plainText);
    string ToPlain(string runeText);
}
