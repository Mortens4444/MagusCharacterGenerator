using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum HorseBadHabit
{
    [Description("Bites")]
    Bites = 1,

    [Description("Kicks")]
    Kicks = 2,

    [Description("Does not gallop")]
    DoesNotGallop = 3,

    [Description("Stubbornly stops")]
    StubbornlyStops = 4,

    [Description("Rubs against fences")]
    RubsAgainstFence = 5,

    [Description("Uncomfortable trot")]
    UncomfortableTrot = 6,

    [Description("Does not jump")]
    DoesNotJump = 7,

    [Description("Freezes in danger")]
    FreezesInDanger = 8,

    [Description("Easily frightened")]
    EasilyFrightened = 9,

    [Description("Suddenly rears")]
    SuddenlyRears = 10
}