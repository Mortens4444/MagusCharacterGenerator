using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Hat
	{
		public string Name => "Hat";

		public Money Price => new Money(0, 0, 150);

		public override string ToString() => Lng.Elem("Hat");
	}
}
