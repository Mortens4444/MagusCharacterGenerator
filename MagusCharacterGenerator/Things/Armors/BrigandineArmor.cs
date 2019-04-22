using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class BrigandineArmor
	{
		public string Name => "Brigandine armor";

		public Money Price => new Money(4, 0, 0);

		public int MovementInhibitingFactor => -2;

		public int DamageSusceptiveValue => 3;

		public int Weight => 15;

		public override string ToString() => Lng.Elem("Brigandine armor");
	}
}
