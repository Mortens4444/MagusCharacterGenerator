using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Calf
	{
		public string Name => "Calf";

		public Money Price => new Money(0, 5, 0);

		public override string ToString() => Lng.Elem("Calf");
	}
}
