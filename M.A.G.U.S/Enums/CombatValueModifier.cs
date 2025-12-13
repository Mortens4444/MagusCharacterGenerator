using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum CombatValueModifier
{
    Base,

    [Description("With primary weapon")]
    PrimaryWeapon,

    [Description("With secondary weapon")]
    SecondaryWeapon
}
