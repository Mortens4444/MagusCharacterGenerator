using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class YokeHorseHarness
	{
		public string Name => "Yoke, horse harness";

		public Money Price => new Money(0, 0, 80);

		public override string ToString() => Lng.Elem("Yoke, horse harness");
	}
}
