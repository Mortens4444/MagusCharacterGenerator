using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.Attributes;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Extensions;

public static class DiceStatExtensions
{
    public static IEnumerable<DiceStat> GetDiceStats(this object instance)
    {
        if (instance == null)
        {
            yield break;
        }

        var type = instance.GetType();
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in props)
        {
            var throwAttr = prop.GetCustomAttributes(false)
                                .OfType<DiceThrowAttribute>()
                                .FirstOrDefault();
            if (throwAttr == null) continue;

            var modAttr = prop.GetCustomAttributes(false)
                              .OfType<DiceThrowModifierAttribute>()
                              .FirstOrDefault();

            var special = prop.GetCustomAttributes(false)
                              .OfType<SpecialTrainingAttribute>()
                              .Any();

            var value = prop.GetValue(instance);

            var formula = throwAttr.DiceThrowType.ToString();
            if (formula.StartsWith("_"))
            {
                formula = formula.TrimStart('_');
            }

            var stat = new DiceStat
            {
                Name = prop.Name,
                Formula = formula,
                Modifier = modAttr != null ? modAttr.Modifier : 0,
                HasSpecialTraining = special,
                Value = value ?? String.Empty
            };

            yield return stat;
        }
    }
}
