using System.Linq;

namespace Storyteller
{
	public static class Grammar
	{
		public static readonly char[] EnglishVowels = { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
		public static readonly char[] Consonant = { 'b', 'B', 'c', 'C', 'd', 'D', 'f', 'F', 'g', 'G', 'h', 'H', 'j', 'J', 'k', 'K', 'l', 'L', 'm', 'M', 'n', 'N', 'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 't', 'T', 'v', 'V', 'w', 'W', 'x', 'X', 'y', 'Y', 'z', 'Z' };

		/// <summary>
		/// Is this character is a vowel(magánhangzó)?
		/// </summary>
		/// <param name="value">Examined character</param>
		/// <returns>True if the character is a vowel, otherwise false.</returns>
		public static bool IsVowel(this char value)
		{
			return EnglishVowels.Any(ch => ch == value);
		}

		/// <summary>
		/// Is this character is a consonant(mássalhangzó)?
		/// </summary>
		/// <param name="value">Examined character</param>
		/// <returns>True if the character is a consonant, otherwise false.</returns>
		public static bool IsConsonant(this char value)
		{
			return Consonant.Any(ch => ch == value);
		}
	}
}
