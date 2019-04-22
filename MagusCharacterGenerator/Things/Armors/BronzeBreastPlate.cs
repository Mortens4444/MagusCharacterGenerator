using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class BronzeBreastPlate
	{
		public string Name => "Bronze breast plate";

		public Money Price => new Money(60, 0, 0);

		public int MovementInhibitingFactor => -4;

		public int DamageSusceptiveValue => 3;

		public int Weight => 20;

		public override string ToString() => Lng.Elem("Bronze breast plate");
	}
}
