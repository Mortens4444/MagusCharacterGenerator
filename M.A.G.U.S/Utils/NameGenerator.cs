using Mtf.Extensions;
using Mtf.Extensions.Services;
using System.Text;
using System.Text.RegularExpressions;

namespace M.A.G.U.S.Utils;

public static partial class NameGenerator
{
	private delegate char CharGenerator();

    private static readonly Random random = new();

	public static string Get()
	{
		var length = RandomProvider.GetSecureRandomShort(5, 12);
		var result = new StringBuilder();

		for (var i = 0; i < length; i++)
		{
			switch (result.Length)
			{
				case 0:
				case 1:
					result.Append(GenerateFromChars(EnglishGrammarExtensions.EnglishVowels, EnglishGrammarExtensions.Consonant));
					break;
				default:
					if (result[^1].IsConsonant() && result[result.Length - 2].IsConsonant())
					{
						result.Append(GenerateFromChars(EnglishGrammarExtensions.EnglishVowels));
					}
					else if (result[^1].IsVowel())
					{
						result.Append(GenerateFromChars(EnglishGrammarExtensions.Consonant));
					}
					else
					{
						result.Append(GenerateFromChars(EnglishGrammarExtensions.EnglishVowels, EnglishGrammarExtensions.Consonant));
					}
					break;
			}

		}
		return result.ToString();
	}

    public static string ToName(this string text)
    {
        if (String.IsNullOrWhiteSpace(text))
            return String.Empty;

        var cleaned = FindUnderscores().Replace(text, " ");
        cleaned = FindNumbers().Replace(cleaned, String.Empty);
        cleaned = FindWhitespaces().Replace(cleaned, " ").Trim();

        if (cleaned.Length == 0)
            return String.Empty;

        cleaned = cleaned.ToLowerInvariant();
        return char.ToUpperInvariant(cleaned[0]) + (cleaned.Length > 1 ? cleaned.Substring(1) : String.Empty);

    }

    private static char GenerateFromChars(IReadOnlyList<char> chars)
	{
		return chars[random.Next(chars.Count)];
	}

	private static char GenerateFromChars(IReadOnlyList<char> chars1, IReadOnlyList<char> chars2)
	{
		return GenerateFromChars(Environment.TickCount % 2 == 0 ? chars1 : chars2);
	}

	[GeneratedRegex("_+")]
	private static partial Regex FindUnderscores();

    [GeneratedRegex(@"\d+")]
    private static partial Regex FindNumbers();

    [GeneratedRegex(@"\s+")]
    private static partial Regex FindWhitespaces();
}
