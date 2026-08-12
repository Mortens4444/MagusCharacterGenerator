using System.ComponentModel;

namespace MAGUS.Enums;

public enum AttackStrategy
{
    [Description("Attack first")]
    AttackFirst,

    [Description("Attack random")]
    AttackRandom,

    [Description("Attack weakest")]
    AttackWeakest,

    [Description("Attack strongest")]
    AttackStrongest
}
