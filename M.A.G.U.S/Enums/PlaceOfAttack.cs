using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PlaceOfAttack
{
    None = 0,
    [Description("Weapon-wielding arm")]
    WeaponWieldingArm = 1 << 0,
    [Description("Non weapon-wielding arm")]
    NonWeaponWieldingArm = 1 << 1,
    [Description("Right leg")]
    RightLeg = 1 << 2,
    [Description("Left leg")]
    LeftLeg = 1 << 3,
    [Description("Head")]
    Head = 1 << 4,
    [Description("Torso")]
    Torso = 1 << 5,

    EveryWhere = WeaponWieldingArm | NonWeaponWieldingArm | RightLeg | LeftLeg | Head | Torso
}
