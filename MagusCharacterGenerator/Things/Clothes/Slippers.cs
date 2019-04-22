using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Slippers
	{
		public string Name => "Slippers";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Slippers");
	}
}
