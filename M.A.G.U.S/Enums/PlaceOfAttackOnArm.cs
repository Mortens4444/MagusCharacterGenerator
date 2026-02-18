using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PlaceOfAttackOnArm
{
    None = 0,
    Shoulder = 1 << 0,
    Wrist = 1 << 1,
    [Description("Back of hand")]
    BackOfHand = 1 << 2,
    Elbow = 1 << 3,
    Forearm = 1 << 4,
    [Description("Upper arm")]
    UpperArm = 1 << 5,

    Everywhere = Shoulder | Wrist | BackOfHand | Elbow | Forearm | UpperArm
}
