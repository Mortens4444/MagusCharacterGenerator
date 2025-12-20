using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Extensions;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Extensions;

internal static class DiceStatExtensions
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
            var customAttributes = prop.GetCustomAttributes(false);
            var diceThrowFormula = customAttributes.GetDiceThrowFormula();
            if (diceThrowFormula != null)
            {
                yield return new DiceStat
                {
                    Formula = diceThrowFormula.Formula,
                    Modifier = diceThrowFormula.Modifier,
                    HasSpecialTraining = diceThrowFormula.HasSpecialTraining,
                    Name = prop.Name,
                    Value = prop.GetValue(instance) ?? String.Empty
                };
            }
        }
    }
}
