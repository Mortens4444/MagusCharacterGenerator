using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class GlovesNoble
	{
		public string Name => "Gloves, noble";

		public Money Price => new Money(0, 3, 0);

		public override string ToString() => Lng.Elem("Gloves, noble");
	}
}
