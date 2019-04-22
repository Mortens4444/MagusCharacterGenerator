using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class HorseHeavyCombat
	{
		public string Name => "Horse, heavy combat";

		public Money Price => new Money(10, 0, 0);

		public override string ToString() => Lng.Elem("Horse, heavy combat");
	}
}
