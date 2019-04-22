using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class SteelLaminarArmour
	{
		public string Name => "Steel laminar armour";

		public Money Price => new Money(40, 0, 0);

		public int MovementInhibitingFactor => -3;

		public int DamageSusceptiveValue => 3;

		public int Weight => 16;

		public override string ToString() => Lng.Elem("Steel laminar armour");
	}
}
