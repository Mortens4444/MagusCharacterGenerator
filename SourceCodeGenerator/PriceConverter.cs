namespace SourceCodeGenerator
{
	static class PriceConverter
	{
		public static string Get(string priceStr)
		{
			var result = "new Money({a}, {e}, {r})";
			var priceParts = priceStr.Split(' ');
			foreach (var pricePart in priceParts)
			{
				var priceUnit = pricePart[pricePart.Length - 1];
				var priceValue = pricePart.Substring(0, pricePart.Length - 1);
				switch (priceUnit)
				{
					case 'a':
						result = result.Replace("{a}", priceValue);
					break;
					case 'e':
						result = result.Replace("{e}", priceValue);
					break;
					case 'r':
						result = result.Replace("{r}", priceValue);
					break;
				}
			}
			result = result.Replace("{a}", "0");
			result = result.Replace("{e}", "0");
			result = result.Replace("{r}", "0");
			return result;
		}
	}
}
