using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class HorseLightCombat
	{
		public string Name => "Horse, light combat";

		public Money Price => new Money(3, 0, 0);

		public override string ToString() => Lng.Elem("Horse, light combat");
	}
}
