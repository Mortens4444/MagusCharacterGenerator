using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum Alignment
{
    Life,
    Death,
    Chaos,
    Order,
    [Description("Chaos, life")]
    ChaosLife,
    [Description("Order, life")]
    OrderLife,
    [Description("Chaos, death")]
    ChaosDeath,
    [Description("Order, death")]
    OrderDeath
}
