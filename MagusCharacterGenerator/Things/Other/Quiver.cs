using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Quiver
	{
		public string Name => "Quiver";

		public Money Price => new Money(0, 0, 150);

		public override string ToString() => Lng.Elem("Quiver");
	}
}
