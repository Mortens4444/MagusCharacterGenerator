namespace MAGUS.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
public class DiceThrowModifierAttribute(int modifier) : Attribute
{
    public int Modifier { get; } = modifier;
}
