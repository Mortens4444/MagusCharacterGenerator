using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class PeasantShirts
	{
		public string Name => "Peasant shirts";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Peasant shirts");
	}
}
