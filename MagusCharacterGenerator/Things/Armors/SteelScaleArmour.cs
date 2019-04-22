using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class SteelScaleArmour
	{
		public string Name => "Steel scale armour";

		public Money Price => new Money(20, 0, 0);

		public int MovementInhibitingFactor => -2;

		public int DamageSusceptiveValue => 3;

		public int Weight => 16;

		public override string ToString() => Lng.Elem("Steel scale armour");
	}
}
