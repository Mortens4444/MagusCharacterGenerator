namespace M.A.G.U.S.GameSystem.Attributes;

public class DiceThrowModifierAttribute : Attribute
{
    public byte Modifier { get; }

    public DiceThrowModifierAttribute(byte modifier)
    {
        Modifier = modifier;
    }
}
