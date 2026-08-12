using MAGUS.Assistant.Models;
using MAGUS.Models;

namespace MAGUS.Assistant.Extensions;

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
        return String.IsNullOrEmpty(formula.Formula) ? diceStat.Modifier.ToString() : diceStat.DisplayFormula;
    }
}
