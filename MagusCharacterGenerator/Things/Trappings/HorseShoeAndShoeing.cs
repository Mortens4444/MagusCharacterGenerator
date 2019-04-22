using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class HorseShoeAndShoeing
	{
		public string Name => "Horse shoe and shoeing";

		public Money Price => new Money(0, 1, 0);

		public override string ToString() => Lng.Elem("Horse shoe and shoeing");
	}
}
