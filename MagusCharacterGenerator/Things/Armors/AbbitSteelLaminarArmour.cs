using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class AbbitSteelLaminarArmour
	{
		public string Name => "Abbit steel laminar armour";

		public Money Price => new Money(100, 0, 0);

		public int MovementInhibitingFactor => -2;

		public int DamageSusceptiveValue => 4;

		public int Weight => 7;

		public override string ToString() => Lng.Elem("Abbit steel laminar armour");
	}
}
