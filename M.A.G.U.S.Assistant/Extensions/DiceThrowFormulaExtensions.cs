using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Assistant.Extensions;

internal static class DiceThrowFormulaExtensions
{
    internal static string GetDisplayFormula(this DiceThrowFormula formula)
    {
        if (formula == null)
        {
            return String.Empty;
        }

        var diceStat = new DiceStat
        {
            Formula = formula.Formula,
            Modifier = formula.Modifier,
            HasSpecialTraining = formula.HasSpecialTraining
        };
        return diceStat.DisplayFormula;
    }
}
