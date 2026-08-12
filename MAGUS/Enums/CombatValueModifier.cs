using System.ComponentModel;

namespace MAGUS.Enums;

public enum CombatValueModifier
{
    [Description("Base")]
    Base,

    [Description("With primary weapon")]
    PrimaryWeapon,

    [Description("With secondary weapon")]
    SecondaryWeapon
}
