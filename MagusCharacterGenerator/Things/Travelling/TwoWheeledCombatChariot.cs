using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class TwoWheeledCombatChariot
	{
		public string Name => "Two wheeled combat chariot";

		public Money Price => new Money(50, 0, 0);

		public override string ToString() => Lng.Elem("Two wheeled combat chariot");
	}
}
