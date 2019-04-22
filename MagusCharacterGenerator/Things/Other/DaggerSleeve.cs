using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class DaggerSleeve
	{
		public string Name => "Dagger Sleeve";

		public Money Price => new Money(0, 1, 0);

		public override string ToString() => Lng.Elem("Dagger Sleeve");
	}
}
