using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class HardenedLeatherArmor
	{
		public string Name => "Hardened leather armor";

		public Money Price => new Money(0, 5, 0);

		public int MovementInhibitingFactor => -2;

		public int DamageSusceptiveValue => 2;

		public int Weight => 7;

		public override string ToString() => Lng.Elem("Hardened leather armor");
	}
}
