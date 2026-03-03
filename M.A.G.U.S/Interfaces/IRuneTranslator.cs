namespace M.A.G.U.S.Interfaces;

public interface IRuneTranslator
{
    string ToRunes(string plainText);
    string ToPlain(string runeText);
}
