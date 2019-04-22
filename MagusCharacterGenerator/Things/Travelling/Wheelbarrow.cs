using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Wheelbarrow
	{
		public string Name => "Wheelbarrow";

		public Money Price => new Money(0, 0, 50);

		public override string ToString() => Lng.Elem("Wheelbarrow");
	}
}
