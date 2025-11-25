using M.A.G.U.S.Races;
using System.Text.RegularExpressions;

namespace M.A.G.U.S.Utils;

public static partial class NameGenerator
{
    public static string Get(IRace? race)
    {
        if (race == null)
        {
            return new Human().GenerateCharacterName();
        }
        return race.GenerateCharacterName();
    }

    public static string ToName(this string text)
    {
        if (String.IsNullOrWhiteSpace(text))
        {
            return String.Empty;
        }

        var cleaned = FindUnderscores().Replace(text, " ");
        cleaned = FindNumbers().Replace(cleaned, String.Empty);
        cleaned = FindWhitespaces().Replace(cleaned, " ").Trim();

        if (cleaned.Length == 0)
        {
            return String.Empty;
        }

        cleaned = cleaned.ToLowerInvariant();
        return char.ToUpperInvariant(cleaned[0]) + (cleaned.Length > 1 ? cleaned.Substring(1) : String.Empty);
    }

    [GeneratedRegex("_+")]
    private static partial Regex FindUnderscores();

    [GeneratedRegex(@"\d+")]
    private static partial Regex FindNumbers();

    [GeneratedRegex(@"\s+")]
    private static partial Regex FindWhitespaces();
}
