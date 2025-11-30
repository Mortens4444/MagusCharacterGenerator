using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum ThingCategory
{
    All,
    Accomodation,
    Animals,
    Armors,
    Clothes,
    Debauchery,
    Food,
    Gemstones,
    [Description("Magical items")]
    MagicalObjects,
    Other,
    Shields,
    Trappings,
    Travelling,
    Weapons,
    [Description("Crushing weapons")]
    CrushingWeapons,
    [Description("Other weapons")]
    OtherWeapons,
    [Description("Ranged weapons")]
    RangedWeapons,
    Spears,
    [Description("Stabbing weapons")]
    StabbingWeapons
}
