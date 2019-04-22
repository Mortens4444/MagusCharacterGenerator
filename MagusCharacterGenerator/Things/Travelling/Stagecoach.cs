using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Stagecoach
	{
		public string Name => "Stagecoach";

		public Money Price => new Money(20, 0, 0);

		public override string ToString() => Lng.Elem("Stagecoach");
	}
}
