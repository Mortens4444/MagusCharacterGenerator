using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class ButterKilo
	{
		public string Name => "Butter, kilo";

		public Money Price => new Money(0, 0, 2);

		public override string ToString() => Lng.Elem("Butter, kilo");
	}
}
