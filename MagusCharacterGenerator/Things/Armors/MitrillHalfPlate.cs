using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class MitrillHalfPlate
	{
		public string Name => "Mitrill half plate";

		public Money Price => new Money(12000, 0, 0);

		public int MovementInhibitingFactor => -3;

		public int DamageSusceptiveValue => 7;

		public int Weight => 8;

		public override string ToString() => Lng.Elem("Mitrill half plate");
	}
}
