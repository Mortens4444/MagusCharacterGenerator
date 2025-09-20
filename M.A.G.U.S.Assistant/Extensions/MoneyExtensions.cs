using M.A.G.U.S.GameSystem.Valuables;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Extensions
{
    public static class MoneyExtensions
    {
        public static string ToTranslatedString(this Money money)
        {
            var parts = new List<string>();

            if (money == null)
            {
                return Lng.Elem("Free");
            }

            if (money.Mithrill != 0)
            {
                parts.Add($"{Lng.Elem(nameof(money.Mithrill))}: {money.Mithrill}");
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

            return parts.Any() ? String.Join(", ", parts) : Lng.Elem("Free");
        }
    }
}
