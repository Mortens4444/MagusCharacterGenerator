using M.A.G.U.S.GameSystem.Attributes;
using Mtf.Extensions;
using System.Reflection;

namespace M.A.G.U.S.Extensions;

public static class EnumExtensions
{
    public static string GetDiceFormula<TEnum>(this TEnum value)
        where TEnum : struct, Enum
    {
        var field = typeof(TEnum).GetField(value.ToString());
        if (field == null)
        {
            return String.Empty;
        }

        var attributes = field.GetCustomAttributes<DiceThrowAttribute>();
        if (!attributes.Any())
        {
            return String.Empty;
        }

        return String.Join(" + ", attributes.Select(a => a.ToString()));
    }
}
