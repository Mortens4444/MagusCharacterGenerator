using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Boots
	{
		public string Name => "Boots";

		public Money Price => new Money(0, 0, 10);

		public override string ToString() => Lng.Elem("Boots");
	}
}
