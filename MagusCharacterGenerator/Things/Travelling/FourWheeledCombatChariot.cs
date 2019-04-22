using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class FourWheeledCombatChariot
	{
		public string Name => "Four wheeled combat chariot";

		public Money Price => new Money(100, 0, 0);

		public override string ToString() => Lng.Elem("Four wheeled combat chariot");
	}
}
