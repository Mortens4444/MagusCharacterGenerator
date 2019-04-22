using System;
using System.Linq;
using System.Text;

namespace Mtf.Helper
{
	public static class StringExtensions
	{
		public static int GetSecondIndexOf(this string text, char ch)
		{
			return text.IndexOf(ch, text.IndexOf(ch) + 1);
		}

		public static string FirstCharToUpper(this string text)
		{
			return text.First().ToString().ToUpper() + text.Substring(1);
		}

		public static string ToName(this string text)
		{
			var result = new StringBuilder();
			result.Append(Char.ToUpper(text.First()));
			result.Append(text.Substring(1).ToLower());
			return result.ToString();
		}

		public static string Join(string separator, params string[] items)
		{
			var result = String.Join(separator, items);

			while (result.StartsWith(separator))
			{
				result = result.Substring(separator.Length);
			}

			while (result.EndsWith(separator))
			{
				result = result.Substring(0, result.Length - separator.Length);
			}

			var concat = string.Concat(separator, separator);
			while (result.Contains(concat))
			{
				result = result.Replace(concat, separator);
			}

			return result;
		}
	}
}
