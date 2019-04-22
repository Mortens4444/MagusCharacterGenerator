using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class FlintAndSteel
	{
		public string Name => "Flint and steel";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Flint and steel");
	}
}
