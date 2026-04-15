using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Services;

public sealed class AutoCombatRollService : ICombatRollService
{
    public Task<int> RollAsync(DiceThrowFormula formula, string title)
    {
        // Convert to internal RollFormula to parse ThrowType, modifier and special training
        var rf = new RollFormula(formula, title);
        var diceThrow = new DiceThrow();
        var result = diceThrow.Throw(rf.ThrowType, rf.Modifier, rf.SpecialTraining);
        return Task.FromResult(result);
    }
}
