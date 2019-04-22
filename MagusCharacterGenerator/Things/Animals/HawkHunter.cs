using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class HawkHunter
	{
		public string Name => "Hawk, hunter";

		public Money Price => new Money(8, 0, 0);

		public override string ToString() => Lng.Elem("Hawk, hunter");
	}
}
