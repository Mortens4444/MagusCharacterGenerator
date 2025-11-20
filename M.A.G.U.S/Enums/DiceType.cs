using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum DiceType
{
    [Description("D2")] D2,
    [Description("D3")] D3,
    [Description("D4")] D4,
    [Description("D6")] D6,
    [Description("D8")] D8,
    [Description("D9")] D9,
    [Description("D10")] D10,
    [Description("D12")] D12,
    [Description("D20")] D20,
    [Description("D100")] D100
}
