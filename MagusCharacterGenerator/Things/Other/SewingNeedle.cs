using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class SewingNeedle
	{
		public string Name => "Sewing needle";

		public Money Price => new Money(0, 0, 3);

		public override string ToString() => Lng.Elem("Sewing needle");
	}
}
