using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class AbbitSteelChainMail
	{
		public string Name => "Abbit steel chain mail";

		public Money Price => new Money(30, 0, 0);

		public int MovementInhibitingFactor => 0;

		public int DamageSusceptiveValue => 4;

		public int Weight => 12;

		public override string ToString() => Lng.Elem("Abbit steel chain mail");
	}
}
