using M.A.G.U.S.GameSystem.Valuables;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Extensions;

internal static class MoneyExtensions
{
    public static string ToTranslatedString(this Money money)
    {
        var parts = new List<string>();

        if (money is null || money.IsZero)
        {
            return Lng.Elem("Free");
        }

        if (money.Mithril != 0)
        {
            parts.Add($"{Lng.Elem(nameof(money.Mithril))}: {money.Mithril}");
        }

        if (money.Gold != 0)
        {
            parts.Add($"{Lng.Elem(nameof(money.Gold))}: {money.Gold}");
        }

        if (money.Silver != 0)
        {
            parts.Add($"{Lng.Elem(nameof(money.Silver))}: {money.Silver}");
        }

        if (money.Copper != 0)
        {
            parts.Add($"{Lng.Elem(nameof(money.Copper))}: {money.Copper}");
        }

        return parts.Count != 0 ? String.Join(", ", parts) : Lng.Elem("Free");
    }
}
