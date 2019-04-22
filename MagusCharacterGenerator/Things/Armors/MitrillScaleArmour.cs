using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class MitrillScaleArmour
	{
		public string Name => "Mitrill scale armour";

		public Money Price => new Money(2000, 0, 0);

		public int MovementInhibitingFactor => 0;

		public int DamageSusceptiveValue => 5;

		public int Weight => 5;

		public override string ToString() => Lng.Elem("Mitrill scale armour");
	}
}
