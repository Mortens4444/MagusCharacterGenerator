namespace M.A.G.U.S.GameSystem.Psi;

public static class PsiUtils
{
    public const byte KyrModifier = 6;
    public const byte SlanModifier = 5;
    public const byte PyarronMasterModifier = 4;
    public const byte PyarronBaseModifier = 3;
    public const byte AdditionalPsiBase = 1;

    public static ushort GetPsiPoints(byte modifier, int spentLevels)
    {
        return (ushort)(modifier * spentLevels + 1);
    }

    public static ushort GetPsiPoints(byte modifier, int masterLevel, int baseLevel)
    {
		return (ushort)(modifier * (masterLevel - (baseLevel - 1)) + AdditionalPsiBase);
    }
}
