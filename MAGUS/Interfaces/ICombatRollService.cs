using MAGUS.Enums;
using MAGUS.Models;

namespace MAGUS.Interfaces;

public interface ICombatRollService
{
    Task<int> RollAsync(ThrowType throwType, string title = "");

    Task<int> RollAsync(RollFormula formula, string title = "");

    Task<int> RollAsync(DiceThrowFormula formula, string title);
}