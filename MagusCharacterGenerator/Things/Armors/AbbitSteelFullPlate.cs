using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class AbbitSteelFullPlate
	{
		public string Name => "Abbit steel full plate";

		public Money Price => new Money(500, 0, 0);

		public int MovementInhibitingFactor => -6;

		public int DamageSusceptiveValue => 7;

		public int Weight => 15;

		public override string ToString() => Lng.Elem("Abbit steel full plate");
	}
}
