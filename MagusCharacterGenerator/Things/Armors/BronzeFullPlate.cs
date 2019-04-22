using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class BronzeFullPlate
	{
		public string Name => "Bronze full plate";

		public Money Price => new Money(160, 0, 0);

		public int MovementInhibitingFactor => -8;

		public int DamageSusceptiveValue => 5;

		public int Weight => 40;

		public override string ToString() => Lng.Elem("Bronze full plate");
	}
}
