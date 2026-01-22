using M.A.G.U.S.Enums;
using Mtf.LanguageService.MAUI;
using System.ComponentModel;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Extensions;

internal static class PlaceOfAttackExtensions
{
    public static string ToLocalizedString(this PlaceOfAttack value)
    {
        if (value == PlaceOfAttack.None)
        {
            return String.Empty;
        }

        var parts = Enum.GetValues<PlaceOfAttack>()
            .Where(v => v != PlaceOfAttack.None && value.HasFlag(v))
            .Select(v => Lng.Elem(v.GetDescription()))
            .ToArray();

        return String.Join(", ", parts);
    }

    private static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attr = field?.GetCustomAttribute<DescriptionAttribute>();

        return attr?.Description ?? value.ToString();
    }
}