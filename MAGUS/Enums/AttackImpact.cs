using System.ComponentModel;

namespace MAGUS.Enums;

public enum AttackImpact
{
    [Description("Normal")]
    Normal,

    [Description("Fatal mistake")]
    FatalMistake = 1,

    [Description("Critical damage")]
    CriticalDamage = 100
}
