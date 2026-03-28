using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum AttackImpact
{
    [Description("Normal")]
    Normal,

    [Description("Fatal mistake")]
    FatalMistake = 1,

    [Description("Critical damage")]
    CriticalDamage = 100
}
