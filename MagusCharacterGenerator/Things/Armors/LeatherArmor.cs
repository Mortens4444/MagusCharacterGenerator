using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class LeatherArmor
	{
		public string Name => "Leather armor";

		public Money Price => new Money(0, 4, 0);

		public int MovementInhibitingFactor => 0;

		public int DamageSusceptiveValue => 1;

		public int Weight => 8;

		public override string ToString() => Lng.Elem("Leather armor");
	}
}
