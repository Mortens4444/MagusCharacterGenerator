using MAGUS.Enums;
using Mtf.Extensions;

namespace MAGUS.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
public class DiceThrowAttribute(ThrowType diceThrowType) : Attribute
{
    public ThrowType DiceThrowType { get; } = diceThrowType;

    public override string ToString()
    {
        return DiceThrowType.GetDescription();
    }
}
