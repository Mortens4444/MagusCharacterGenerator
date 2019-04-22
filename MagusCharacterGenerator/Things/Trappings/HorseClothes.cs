using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class HorseClothes
	{
		public string Name => "Horse clothes";

		public Money Price => new Money(0, 0, 4);

		public override string ToString() => Lng.Elem("Horse clothes");
	}
}
