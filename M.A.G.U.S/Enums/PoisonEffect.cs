using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PoisonEffect
{
    None = 0,
    Cramps = 1 << 0,
    Death = 1 << 1,
    Dizziness = 1 << 2,
    Fainting = 1 << 3,
    Malaise = 1 << 4,
    Nausea = 1 << 5,
    Paralysis = 1 << 6,
    [Description("PTP Loss")]
    PtpLoss = 1 << 7,
    Sleep = 1 << 8,
    Stupor = 1 << 9,
    Weakness = 1 << 10
}
