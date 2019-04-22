using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Hood
	{
		public string Name => "Hood";

		public Money Price => new Money(0, 0, 8);

		public override string ToString() => Lng.Elem("Hood");
	}
}
