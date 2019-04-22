using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class AbbitSteelHalfPlate
	{
		public string Name => "Abbit steel half plate";

		public Money Price => new Money(300, 0, 0);

		public int MovementInhibitingFactor => -4;

		public int DamageSusceptiveValue => 6;

		public int Weight => 12;

		public override string ToString() => Lng.Elem("Abbit steel half plate");
	}
}
