using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Climbingirons
	{
		public string Name => "Climbing-irons";

		public Money Price => new Money(0, 0, 3);

		public override string ToString() => Lng.Elem("Climbing-irons");
	}
}
