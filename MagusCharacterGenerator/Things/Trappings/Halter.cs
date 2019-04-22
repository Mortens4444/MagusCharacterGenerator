using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class Halter
	{
		public string Name => "Halter";

		public Money Price => new Money(0, 0, 3);

		public override string ToString() => Lng.Elem("Halter");
	}
}
