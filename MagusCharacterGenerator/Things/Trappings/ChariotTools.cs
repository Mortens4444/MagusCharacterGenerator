using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class ChariotTools
	{
		public string Name => "Chariot tools";

		public Money Price => new Money(0, 6, 0);

		public override string ToString() => Lng.Elem("Chariot tools");
	}
}
