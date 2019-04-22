using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class RingArmour
	{
		public string Name => "Ring armour";

		public Money Price => new Money(2, 0, 0);

		public int MovementInhibitingFactor => -1;

		public int DamageSusceptiveValue => 1;

		public int Weight => 12;

		public override string ToString() => Lng.Elem("Ring armour");
	}
}
