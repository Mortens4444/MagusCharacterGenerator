using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class MilkJug
	{
		public string Name => "Milk, jug";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Milk, jug");
	}
}
