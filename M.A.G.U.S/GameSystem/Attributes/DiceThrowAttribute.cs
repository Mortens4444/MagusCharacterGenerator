using M.A.G.U.S.Enums;
using Mtf.Extensions;

namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Field)]
public class DiceThrowAttribute(ThrowType diceThrowType) : Attribute
{
    public ThrowType DiceThrowType { get; } = diceThrowType;

    public override string ToString()
    {
        return DiceThrowType.GetDescription();
    }
}
