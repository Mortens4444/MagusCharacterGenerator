using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PlaceOfAttackOnArm
{
    [Description("None")]
    None = 0,

    [Description("Shoulder")]
    Shoulder = 1 << 0,

    [Description("Wrist")]
    Wrist = 1 << 1,

    [Description("Back of hand")]
    BackOfHand = 1 << 2,

    [Description("Elbow")]
    Elbow = 1 << 3,

    [Description("Forearm")]
    Forearm = 1 << 4,

    [Description("Upper arm")]
    UpperArm = 1 << 5,

    [Description("Everywhere")]
    Everywhere = Shoulder | Wrist | BackOfHand | Elbow | Forearm | UpperArm
}
