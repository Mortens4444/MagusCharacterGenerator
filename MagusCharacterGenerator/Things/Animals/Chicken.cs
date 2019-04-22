using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Chicken
	{
		public string Name => "Chicken";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Chicken");
	}
}
