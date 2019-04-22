using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class LightChainMail
	{
		public string Name => "Light chain mail";

		public Money Price => new Money(10, 0, 0);

		public int MovementInhibitingFactor => -1;

		public int DamageSusceptiveValue => 2;

		public int Weight => 20;

		public override string ToString() => Lng.Elem("Light chain mail");
	}
}
