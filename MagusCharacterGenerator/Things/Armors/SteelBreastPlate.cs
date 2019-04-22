using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class SteelBreastPlate
	{
		public string Name => "Steel breast plate";

		public Money Price => new Money(80, 0, 0);

		public int MovementInhibitingFactor => -4;

		public int DamageSusceptiveValue => 4;

		public int Weight => 18;

		public override string ToString() => Lng.Elem("Steel breast plate");
	}
}
