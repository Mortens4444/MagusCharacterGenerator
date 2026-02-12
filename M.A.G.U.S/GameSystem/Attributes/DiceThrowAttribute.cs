using M.A.G.U.S.Enums;

namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
public class DiceThrowAttribute(ThrowType diceThrowType) : Attribute
{
    public ThrowType DiceThrowType { get; } = diceThrowType;
}
