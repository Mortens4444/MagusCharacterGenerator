using System.ComponentModel;

namespace MAGUS.Enums;

public enum NecrographyDepartment
{
    [Description("I., unconscious undead")]
    UnconsciousUndead,

    [Description("II., night monster")]
    NightMonster,

    [Description("III., wandering corpse")]
    WanderingCorpse,

    [Description("IV., blood-drinking undead")]
    BloodDrinkingUndead,

    [Description("V., incubus")]
    Incubus,

    [Description("VI., ghost")]
    Ghost,

    [Description("III., spirit feeding on vitality")]
    SpiritFeedingOnVitality
}
