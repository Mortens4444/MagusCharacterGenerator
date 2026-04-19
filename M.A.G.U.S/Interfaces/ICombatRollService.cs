using M.A.G.U.S.Enums;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Interfaces;

public interface ICombatRollService
{
    Task<int> RollAsync(ThrowType throwType, string title = "");

    Task<int> RollAsync(RollFormula formula, string title = "");

    Task<int> RollAsync(DiceThrowFormula formula, string title);
}