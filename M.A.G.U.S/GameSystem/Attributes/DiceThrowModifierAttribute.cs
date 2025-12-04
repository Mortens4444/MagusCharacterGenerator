namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
public class DiceThrowModifierAttribute(byte modifier) : Attribute
{
    public byte Modifier { get; } = modifier;
}
