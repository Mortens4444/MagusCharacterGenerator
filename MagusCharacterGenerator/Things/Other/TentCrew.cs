using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class TentCrew
	{
		public string Name => "Tent, crew";

		public Money Price => new Money(3, 0, 0);

		public override string ToString() => Lng.Elem("Tent, crew");
	}
}
