using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class MitrillChainMail
	{
		public string Name => "Mitrill chain mail";

		public Money Price => new Money(1200, 0, 0);

		public int MovementInhibitingFactor => 0;

		public int DamageSusceptiveValue => 5;

		public int Weight => 10;

		public override string ToString() => Lng.Elem("Mitrill chain mail");
	}
}
