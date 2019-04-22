using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class FishOneDose
	{
		public string Name => "Fish, one dose";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Fish, one dose");
	}
}
