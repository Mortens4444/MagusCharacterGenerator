using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using Mtf.Extensions;

namespace M.A.G.U.S.Assistant.Extensions;

public static class ObjectArrayExtensions
{
    public static DiceThrowFormula? GetDiceStat(this object[]? customAttributes)
    {
        var throwAttributes = customAttributes?.OfType<DiceThrowAttribute>().ToArray();
        if (throwAttributes == null || throwAttributes.Length == 0)
        {
            return null;
        }

        var modifierAttribute = customAttributes?.OfType<DiceThrowModifierAttribute>().FirstOrDefault();
        var hasSpecialTraining = customAttributes?.OfType<SpecialTrainingAttribute>().Any() ?? false;

        var formula = String.Join(" + ", throwAttributes.Select(a => a.DiceThrowType.GetDescription()));
        if (formula.StartsWith('_'))
        {
            formula = formula.TrimStart('_');
        }
        return new DiceThrowFormula
        {
            Formula = formula,
            Modifier = modifierAttribute != null ? modifierAttribute.Modifier : 0,
            HasSpecialTraining = hasSpecialTraining
        };
    }
}
