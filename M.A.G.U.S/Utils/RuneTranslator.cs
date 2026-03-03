using M.A.G.U.S.GameSystem.Runes;
using M.A.G.U.S.Interfaces;
using System.Globalization;
using StringBuilder = System.Text.StringBuilder;

namespace M.A.G.U.S.Utils;

public sealed class RuneTranslator : IRuneTranslator
{
    private static readonly Dictionary<string, char> plainToRune;
    private static readonly Dictionary<char, string> runeToPlain;

    static RuneTranslator()
    {
        var runeType = typeof(Rune);

        var runes = runeType.Assembly
            .GetTypes()
            .Where(t => !t.IsAbstract && runeType.IsAssignableFrom(t))
            .Select(t => (Rune)Activator.CreateInstance(t)!)
            .ToList();

        plainToRune = new Dictionary<string, char>(StringComparer.OrdinalIgnoreCase);
        runeToPlain = [];

        foreach (var rune in runes)
        {
            if (!plainToRune.ContainsKey(rune.Equivalent))
            {
                plainToRune[rune.Equivalent] = rune.Sign;
            }

            if (!runeToPlain.ContainsKey(rune.Sign))
            {
                runeToPlain[rune.Sign] = rune.Equivalent;
            }
        }
    }

    public string ToRunes(string plainText)
    {
        if (String.IsNullOrWhiteSpace(plainText))
        {
            return String.Empty;
        }

        var normalized = RemoveDiacritics(plainText).ToUpperInvariant();
        var sb = new StringBuilder(normalized.Length);
        foreach (var ch in normalized)
        {
            var key = ch.ToString();

            if (plainToRune.TryGetValue(key, out var rune))
            {
                sb.Append(rune);
            }
            else
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }

    public string ToPlain(string runeText)
    {
        if (String.IsNullOrWhiteSpace(runeText))
        {
            return String.Empty;
        }

        var sb = new StringBuilder();

        foreach (var ch in runeText)
        {
            if (runeToPlain.TryGetValue(ch, out var plain))
            {
                sb.Append(plain);
            }
            else
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }

    private static string RemoveDiacritics(string text)
    {
        if (String.IsNullOrWhiteSpace(text))
        {
            return String.Empty;
        }

        var normalized = text.Normalize(System.Text.NormalizationForm.FormD);
        var sb = new StringBuilder(normalized.Length);

        foreach (var ch in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(ch);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(ch);
            }
        }

        return sb.ToString().Normalize(System.Text.NormalizationForm.FormC);
    }
}