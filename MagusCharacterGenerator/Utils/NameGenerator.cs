using Mtf.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagusCharacterGenerator.Utils
{
	public static class NameGenerator
	{
		private delegate char CharGenerator();

		private static readonly Random random = new Random();

		public static string Get()
		{
			var length = RandomGenerator.Get(5, 12);
			var result = new StringBuilder();

			for (var i = 0; i < length; i++)
			{
				switch (result.Length)
				{
					case 0:
					case 1:
						result.Append(GenerateFromChars(Grammar.EnglishVowels, Grammar.Consonant));
						break;
					default:
						if (result[result.Length - 1].IsConsonant() && result[result.Length - 2].IsConsonant())
						{
							result.Append(GenerateFromChars(Grammar.EnglishVowels));
						}
						else if (result[result.Length - 1].IsVowel())
						{
							result.Append(GenerateFromChars(Grammar.Consonant));
						}
						else
						{
							result.Append(GenerateFromChars(Grammar.EnglishVowels, Grammar.Consonant));
						}
						break;
				}

			}
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
}
