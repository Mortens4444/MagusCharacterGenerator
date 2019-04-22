using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class SugarGlass
	{
		public string Name => "Sugar, glass";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Sugar, glass");
	}
}
