using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum HorseSpecialAbility
{
    [Description("Fights in battle")]
    FightsInBattle = 1,

    [Description("Loyal")]
    Loyal = 2,

    [Description("Warns of danger")]
    WarnsOfDanger = 3,

    [Description("Comes to whistle")]
    ComesToWhistle = 4,

    [Description("Finds the way home")]
    FindsWayHome = 5,

    [Description("Lies down on command")]
    LiesDownOnCommand = 6,

    [Description("Stops on command")]
    StopsOnCommand = 7,

    [Description("Stays silent on command")]
    StaysSilentOnCommand = 8,

    [Description("Good jumper")]
    GoodJumper = 9,

    [Description("Calm and obedient")]
    CalmAndObedient = 10
}