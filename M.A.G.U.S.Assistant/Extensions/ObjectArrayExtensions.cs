using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Assistant.Extensions;

public static class ObjectArrayExtensions
{
    public static DiceThrowFormula? GetDiceStat(this object[]? customAttributes)
    {
        var throwAttr = customAttributes?.OfType<DiceThrowAttribute>().FirstOrDefault();
        if (throwAttr == null)
        {
            return null;
        }

        var modifierAttribute = customAttributes?.OfType<DiceThrowModifierAttribute>().FirstOrDefault();
        var hasSpecialTraining = customAttributes?.OfType<SpecialTrainingAttribute>().Any() ?? false;

        var formula = throwAttr.DiceThrowType.ToString();
        if (formula.StartsWith('_'))
        {
            formula = formula.TrimStart('_');
        }
        return new DiceThrowFormula
        {
            Formula = formula,
            Modifier = modifierAttribute != null ? modifierAttribute.Modifier : 0,
            HasSpecialTraining = hasSpecialTraining
        }; ;
    }
}
