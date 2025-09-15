using Mtf.Extensions;
using Mtf.Extensions.Services;
using System.Text;

namespace M.A.G.U.S.Utils;

public static class NameGenerator
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
        var result = new StringBuilder();
        result.Append(Char.ToUpper(text.First()));
        result.Append(text.Substring(1).ToLower());
        return result.ToString();
    }

    private static char GenerateFromChars(IReadOnlyList<char> chars)
	{
		return chars[random.Next(chars.Count)];
	}

	private static char GenerateFromChars(IReadOnlyList<char> chars1, IReadOnlyList<char> chars2)
	{
		return GenerateFromChars(Environment.TickCount % 2 == 0 ? chars1 : chars2);
	}
}
