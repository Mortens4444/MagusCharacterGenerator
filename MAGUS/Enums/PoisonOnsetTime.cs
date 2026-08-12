using MAGUS.GameSystem.Attributes;
using System.ComponentModel;

namespace MAGUS.Enums;

public enum PoisonOnsetTime
{
    [Description("Immediate Effect")]
    [DiceThrow(ThrowType._1D10)] // seconds
    Immediate,

    [Description("Fast Effect")]
    [DiceThrow(ThrowType._1D6)] // rounds
    Fast,

    [Description("Slow Effect")]
    [DiceThrow(ThrowType._2D6)] // hours
    Slow,

    [Description("Very Slow Effect")]
    [DiceThrow(ThrowType._1D6)] // days
    VerySlow,

    [Description("Latent / Conditional Effect")]
    Latent
}
