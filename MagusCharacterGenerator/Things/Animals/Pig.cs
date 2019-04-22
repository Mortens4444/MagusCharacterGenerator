using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Pig
	{
		public string Name => "Pig";

		public Money Price => new Money(0, 3, 0);

		public override string ToString() => Lng.Elem("Pig");
	}
}
