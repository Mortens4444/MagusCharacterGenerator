using M.A.G.U.S.GameSystem.Attributes;
using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum Size
{
    [Description("Coin")]
    [DefenseHelper(65)]
    [DistanceModifier(-GameSystem.Constants.DefaultEncounterDistance * 0.9)]
    _1_inch,

    [Description("Apple")]
    [DefenseHelper(50)]
    [DistanceModifier(-GameSystem.Constants.DefaultEncounterDistance * 0.85)]
    _3_inches,

    [DefenseHelper(20)]
    [DistanceModifier(-GameSystem.Constants.DefaultEncounterDistance * 0.7)]
    Small,

    [Description("Maximum 1 meter")]
    [DefenseHelper(15)]
    [DistanceModifier(-GameSystem.Constants.DefaultEncounterDistance * 0.6)]
    Maximum_1_meter,

    [Description("Withers height: 120 cm")]
    [DefenseHelper(10)]
    [DistanceModifier(-GameSystem.Constants.DefaultEncounterDistance * 0.5)]
    WithersHeight_1_20_meter,

    [Description("1.5 meters")]
    [DefenseHelper(5)]
    [DistanceModifier(-GameSystem.Constants.DefaultEncounterDistance * 0.3)]
    _1_5_meters,

    [DefenseHelper(0)]
    [DistanceModifier(0)]
    Human,

    [DefenseHelper(-15)]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 0.3)]
    Big,

    [Description("Up to 3 meters")]
    [DefenseHelper(-20)]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 0.5)]
    Up_to_3_meters,

    [DefenseHelper(-25)]
    [Description("4 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 1)]
    _4_meters,

    [DefenseHelper(-30)]
    [Description("4 to 5.5 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 1.5)]
    _4_to_5_5_meters,

    [DefenseHelper(-30)]
    [Description("4 to 6 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 1.6)]
    _4_to_6_meters,

    [DefenseHelper(-35)]
    [Description("About 6 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 2)]
    About_6_meters,

    [DefenseHelper(-40)]
    [Description("About 7 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 2.5)]
    About_7_meters,

    [DefenseHelper(-45)]
    [Description("About 8 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 3)]
    About_8_meters,

    [DefenseHelper(-35)]
    [Description("6 to 8 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 2.5)]
    _6_to_8_meters,

    [DefenseHelper(-50)]
    [Description("About 8.5 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 3.25)]
    About_8_5_meters,

    [DefenseHelper(-70)]
    [Description("7 to 11 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 5)]
    _7_to_11_meters,

    [DefenseHelper(-85)]
    [Description("Up to 15 meters")]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 6.5)]
    Up_to_15_meters,

    [DefenseHelper(-100)]
    [DistanceModifier(GameSystem.Constants.DefaultEncounterDistance * 10)]
    Huge,
}
