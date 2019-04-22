using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Chiffon
	{
		public string Name => "Chiffon";

		public Money Price => new Money(0, 3, 0);

		public override string ToString() => Lng.Elem("Chiffon");
	}
}
