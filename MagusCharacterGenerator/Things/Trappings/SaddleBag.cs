using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class SaddleBag
	{
		public string Name => "Saddle bag";

		public Money Price => new Money(0, 1, 0);

		public override string ToString() => Lng.Elem("Saddle bag");
	}
}
