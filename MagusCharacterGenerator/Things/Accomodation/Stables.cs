using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Accomodation
{
	class Stables
	{
		public string Name => "Stables";

		public Money Price => new Money(0, 0, 2);

		public override string ToString() => Lng.Elem("Stables");
	}
}
