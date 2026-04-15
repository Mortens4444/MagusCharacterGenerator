using M.A.G.U.S.Models;

namespace M.A.G.U.S.Interfaces;

public interface ICombatRollService
{
    Task<int> RollAsync(DiceThrowFormula formula, string title);
}