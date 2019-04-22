using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class MirrorMetal
	{
		public string Name => "Mirror, metal";

		public Money Price => new Money(0, 0, 10);

		public override string ToString() => Lng.Elem("Mirror, metal");
	}
}
