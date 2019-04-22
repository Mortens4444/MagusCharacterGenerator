using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Sack
	{
		public string Name => "Sack";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Sack");
	}
}
