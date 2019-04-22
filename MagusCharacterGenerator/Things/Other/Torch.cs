using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Torch
	{
		public string Name => "Torch";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Torch");
	}
}
