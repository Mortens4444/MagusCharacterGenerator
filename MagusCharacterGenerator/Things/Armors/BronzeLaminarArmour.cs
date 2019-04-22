using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class BronzeLaminarArmour
	{
		public string Name => "Bronze laminar armour";

		public Money Price => new Money(30, 0, 0);

		public int MovementInhibitingFactor => -3;

		public int DamageSusceptiveValue => 2;

		public int Weight => 18;

		public override string ToString() => Lng.Elem("Bronze laminar armour");
	}
}
