using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class SwordholeOrdinary
	{
		public string Name => "Swordhole, ordinary";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Swordhole, ordinary");
	}
}
