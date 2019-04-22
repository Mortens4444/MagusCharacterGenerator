using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class BronzeHalfPlate
	{
		public string Name => "Bronze half plate";

		public Money Price => new Money(100, 0, 0);

		public int MovementInhibitingFactor => -6;

		public int DamageSusceptiveValue => 4;

		public int Weight => 35;

		public override string ToString() => Lng.Elem("Bronze half plate");
	}
}
