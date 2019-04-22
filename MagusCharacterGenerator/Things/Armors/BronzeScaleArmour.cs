using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class BronzeScaleArmour
	{
		public string Name => "Bronze scale armour";

		public Money Price => new Money(16, 0, 0);

		public int MovementInhibitingFactor => -2;

		public int DamageSusceptiveValue => 2;

		public int Weight => 18;

		public override string ToString() => Lng.Elem("Bronze scale armour");
	}
}
