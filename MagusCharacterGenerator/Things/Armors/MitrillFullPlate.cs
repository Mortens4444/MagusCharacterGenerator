using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class MitrillFullPlate
	{
		public string Name => "Mitrill full plate";

		public Money Price => new Money(20000, 0, 0);

		public int MovementInhibitingFactor => -4;

		public int DamageSusceptiveValue => 8;

		public int Weight => 10;

		public override string ToString() => Lng.Elem("Mitrill full plate");
	}
}
