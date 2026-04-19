using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Services;

public sealed class AutoCombatRollService : ICombatRollService
{
    private readonly DiceThrow diceThrow = new();

    public Task<int> RollAsync(RollFormula formula, string title = "")
    {
        var diceThrow = new DiceThrow();
        var result = diceThrow.Throw(formula.ThrowType, formula.Modifier, formula.SpecialTraining);
        return Task.FromResult(result);
    }

    public Task<int> RollAsync(DiceThrowFormula formula, string title)
    {
        // Convert to internal RollFormula to parse ThrowType, modifier and special training
        var rf = new RollFormula(formula, title);
        var diceThrow = new DiceThrow();
        var result = diceThrow.Throw(rf.ThrowType, rf.Modifier, rf.SpecialTraining);
        return Task.FromResult(result);
    }

    public Task<int> RollAsync(ThrowType throwType, string title = "") => Task.FromResult(diceThrow.Throw(throwType));
}
