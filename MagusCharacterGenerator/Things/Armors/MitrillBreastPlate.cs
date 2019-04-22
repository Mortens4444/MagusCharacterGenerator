using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class MitrillBreastPlate
	{
		public string Name => "Mitrill breast plate";

		public Money Price => new Money(8000, 0, 0);

		public int MovementInhibitingFactor => -1;

		public int DamageSusceptiveValue => 6;

		public int Weight => 6;

		public override string ToString() => Lng.Elem("Mitrill breast plate");
	}
}
