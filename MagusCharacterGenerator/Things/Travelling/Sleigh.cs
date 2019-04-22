using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Sleigh
	{
		public string Name => "Sleigh";

		public Money Price => new Money(5, 0, 0);

		public override string ToString() => Lng.Elem("Sleigh");
	}
}
