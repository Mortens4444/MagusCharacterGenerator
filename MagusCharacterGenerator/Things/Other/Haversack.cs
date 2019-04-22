using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Haversack
	{
		public string Name => "Haversack";

		public Money Price => new Money(0, 0, 40);

		public override string ToString() => Lng.Elem("Haversack");
	}
}
