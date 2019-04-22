using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Saru
	{
		public string Name => "Saru";

		public Money Price => new Money(0, 0, 3);

		public override string ToString() => Lng.Elem("Saru");
	}
}
