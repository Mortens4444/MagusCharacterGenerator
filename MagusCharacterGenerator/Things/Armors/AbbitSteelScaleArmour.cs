using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class AbbitSteelScaleArmour
	{
		public string Name => "Abbit steel scale armour";

		public Money Price => new Money(50, 0, 0);

		public int MovementInhibitingFactor => -1;

		public int DamageSusceptiveValue => 4;

		public int Weight => 7;

		public override string ToString() => Lng.Elem("Abbit steel scale armour");
	}
}
