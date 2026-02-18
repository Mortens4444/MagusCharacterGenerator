using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PlaceOfAttackOnTorsoFromBehind
{
    None = 0,
    [Description("Right shoulder blade")]
    RightShoulderBlade = 1 << 0,
    [Description("Left shoulder blade")]
    LeftShoulderBlade = 1 << 1,
    [Description("Right side of back")]
    RightSideOfBack = 1 << 2,
    [Description("Left side of back")]
    LeftSideOfBack = 1 << 3,
    [Description("Right side of waist")]
    RightSideOfWaist = 1 << 4,
    [Description("Left side of waist")]
    LeftSideOfWaist = 1 << 5,
    Buttocks = 1 << 6,
    Spine = 1 << 7,

    Everywhere = RightShoulderBlade | LeftShoulderBlade | RightSideOfBack | LeftSideOfBack | RightSideOfWaist | LeftSideOfWaist | Buttocks | Spine
}
