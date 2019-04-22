using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class SteelHalfPlate
	{
		public string Name => "Steel half plate";

		public Money Price => new Money(120, 0, 0);

		public int MovementInhibitingFactor => -6;

		public int DamageSusceptiveValue => 5;

		public int Weight => 30;

		public override string ToString() => Lng.Elem("Steel half plate");
	}
}
