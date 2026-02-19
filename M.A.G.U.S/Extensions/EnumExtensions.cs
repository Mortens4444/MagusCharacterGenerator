using M.A.G.U.S.GameSystem.Attributes;
using Mtf.Extensions;
using System.Reflection;

namespace M.A.G.U.S.Extensions;

public static class EnumExtensions
{
    public static string GetDiceFormula<TEnum>(this TEnum value)
        where TEnum : struct, Enum
    {
        var type = typeof(TEnum);
        var name = value.ToString();

        var field = type.GetField(name);
        if (field == null)
            return String.Empty;

        var attribute = field.GetCustomAttribute<DiceThrowAttribute>();
        return attribute.GetDescription();
    }
}
