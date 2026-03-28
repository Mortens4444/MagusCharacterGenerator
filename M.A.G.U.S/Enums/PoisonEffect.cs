using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PoisonEffect
{
    [Description("None")]
    None = 0,

    [Description("Cramps")]
    Cramps = 1 << 0,

    [Description("Death")]
    Death = 1 << 1,

    [Description("Dizziness")]
    Dizziness = 1 << 2,

    [Description("Fainting")]
    Fainting = 1 << 3,

    [Description("Malaise")]
    Malaise = 1 << 4,

    [Description("Nausea")]
    Nausea = 1 << 5,

    [Description("Paralysis")]
    Paralysis = 1 << 6,

    [Description("PTP Loss")]
    PtpLoss = 1 << 7,

    [Description("Sleep")]
    Sleep = 1 << 8,

    [Description("Stupor")]
    Stupor = 1 << 9,

    [Description("Weakness")]
    Weakness = 1 << 10
}
