using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Ferry
	{
		public string Name => "Ferry";

		public Money Price => new Money(0, 0, 10);

		public override string ToString() => Lng.Elem("Ferry");
	}
}
