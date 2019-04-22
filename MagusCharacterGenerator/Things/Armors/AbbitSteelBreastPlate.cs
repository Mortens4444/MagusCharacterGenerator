using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class AbbitSteelBreastPlate
	{
		public string Name => "Abbit steel breast plate";

		public Money Price => new Money(200, 0, 0);

		public int MovementInhibitingFactor => -2;

		public int DamageSusceptiveValue => 8;

		public int Weight => 12;

		public override string ToString() => Lng.Elem("Abbit steel breast plate");
	}
}
