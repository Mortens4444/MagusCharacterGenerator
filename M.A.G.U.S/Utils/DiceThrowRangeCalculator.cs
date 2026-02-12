using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Utils;

public static class DiceThrowRangeCalculator
{
    public static DiceRange GetRange(ThrowType throwType, int modifier = 0, bool specialTraining = false)
    {
        var diceThrow = new DiceThrow();
        var x = diceThrow.GetRange(throwType, modifier, specialTraining);
        return new DiceRange(x.Min, x.Max);
    }
}
