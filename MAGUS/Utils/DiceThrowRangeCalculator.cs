using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.Models;

namespace MAGUS.Utils;

public static class DiceThrowRangeCalculator
{
    public static DiceRange GetRange(ThrowType throwType, int modifier = 0, bool specialTraining = false)
    {
        var diceThrow = new DiceThrow();
        var x = diceThrow.GetRange(throwType, modifier, specialTraining);
        return new DiceRange(x.Min, x.Max);
    }
}
