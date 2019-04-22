using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class SteelFullPlate
	{
		public string Name => "Steel full plate";

		public Money Price => new Money(200, 0, 0);

		public int MovementInhibitingFactor => -8;

		public int DamageSusceptiveValue => 6;

		public int Weight => 35;

		public override string ToString() => Lng.Elem("Steel full plate");
	}
}
