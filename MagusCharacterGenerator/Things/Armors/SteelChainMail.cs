using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class SteelChainMail
	{
		public string Name => "Steel chain mail";

		public Money Price => new Money(12, 0, 0);

		public int MovementInhibitingFactor => -1;

		public int DamageSusceptiveValue => 3;

		public int Weight => 20;

		public override string ToString() => Lng.Elem("Steel chain mail");
	}
}
