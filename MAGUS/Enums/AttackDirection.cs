using System.ComponentModel;

namespace MAGUS.Enums;

public enum AttackDirection
{
    [Description("From the front")]
    Front,

    [Description("From half behind")]
    HalfBehind,

    [Description("From behind")]
    Behind
}
