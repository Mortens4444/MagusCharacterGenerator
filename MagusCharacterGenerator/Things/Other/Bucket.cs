using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Bucket
	{
		public string Name => "Bucket";

		public Money Price => new Money(0, 1, 0);

		public override string ToString() => Lng.Elem("Bucket");
	}
}
