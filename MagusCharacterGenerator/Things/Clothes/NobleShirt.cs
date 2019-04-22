using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class NobleShirt
	{
		public string Name => "Noble shirt";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Noble shirt");
	}
}
