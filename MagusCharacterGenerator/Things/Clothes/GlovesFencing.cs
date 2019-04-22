using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class GlovesFencing
	{
		public string Name => "Gloves, fencing";

		public Money Price => new Money(0, 1, 0);

		public override string ToString() => Lng.Elem("Gloves, fencing");
	}
}
