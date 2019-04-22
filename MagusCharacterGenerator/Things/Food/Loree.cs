using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class Loree
	{
		public string Name => "Loree";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Loree");
	}
}
