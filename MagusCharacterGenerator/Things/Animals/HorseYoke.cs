using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class HorseYoke
	{
		public string Name => "Horse, yoke";

		public Money Price => new Money(0, 8, 0);

		public override string ToString() => Lng.Elem("Horse, yoke");
	}
}
