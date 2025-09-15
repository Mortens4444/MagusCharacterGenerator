namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
public class DiceThrowAttribute : Attribute
{
    public ThrowType DiceThrowType { get; }

    public DiceThrowAttribute(ThrowType diceThrowType)
    {
        DiceThrowType = diceThrowType;
    }
}
