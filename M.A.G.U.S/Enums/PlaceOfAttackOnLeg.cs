using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PlaceOfAttackOnLeg
{
    [Description("None")]
    None = 0,

    [Description("Thigh")]
    Thigh = 1 << 0,

    [Description("Knee")]
    Knee = 1 << 1,

    [Description("Ankle")]
    Ankle = 1 << 2,

    [Description("Shin")]
    Shin = 1 << 3,

    [Description("Foot")]
    Foot = 1 << 4,

    [Description("Everywhere")]
    Everywhere = Thigh | Knee | Shin | Ankle | Foot
}
