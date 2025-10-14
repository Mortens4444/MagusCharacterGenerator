using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum PlaceOfAttack
{
    [Description("Weapon-wielding arm")]
    WeaponWieldingArm,
    [Description("Non weapon-wielding arm")]
    NonWeaponWieldingArm,
    [Description("Right leg")]
    RightLeg,
    [Description("Left leg")]
    LeftLeg,
    [Description("Head")]
    Head,
    [Description("Torso")]
    Torso,
}
