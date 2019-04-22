using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class MitrillLaminarArmour
	{
		public string Name => "Mitrill laminar armour";

		public Money Price => new Money(4000, 0, 0);

		public int MovementInhibitingFactor => -1;

		public int DamageSusceptiveValue => 5;

		public int Weight => 5;

		public override string ToString() => Lng.Elem("Mitrill laminar armour");
	}
}
