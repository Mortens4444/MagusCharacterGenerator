using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Hen
	{
		public string Name => "Hen";

		public Money Price => new Money(0, 0, 7);

		public override string ToString() => Lng.Elem("Hen");
	}
}
