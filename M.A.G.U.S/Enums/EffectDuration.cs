using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum EffectDuration
{
    [Description("Single-effect")]
    SingleEffect,

    [Description("Short-acting poisons")]
    ShortActingPoisons,

    [Description("Medium-duration poisons")]
    MediumDurationPoisons,
    
    [Description("Long-acting poisons")]
    LongActingPoisons,

    [Description("Poisons with permanent effects")]
    PoisonsWithPermanentEffects
}
