using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Deadboltpadlock
	{
		public string Name => "Deadbolt/padlock";

		public Money Price => new Money(0, 3, 0);

		public override string ToString() => Lng.Elem("Deadbolt/padlock");
	}
}
