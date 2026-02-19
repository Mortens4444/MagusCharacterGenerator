using M.A.G.U.S.GameSystem.Attributes;
using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum PoisonDuration
{
    [Description("Single Effect")]
    SingleEffect,

    [DiceThrow(ThrowType._1D6)] // Minutes
    [Description("Short Duration Poison")]
    ShortDuration,

    [DiceThrow(ThrowType._1D6)] // Hours
    [Description("Medium Duration Poison")]
    MediumDuration,

    [DiceThrow(ThrowType._1D6)] // days
    [Description("Long Duration Poison")]
    LongDuration,

    [Description("Permanent Effect Poison")]
    Permanent
}
