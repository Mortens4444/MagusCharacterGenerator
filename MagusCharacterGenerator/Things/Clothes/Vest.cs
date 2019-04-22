using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Vest
	{
		public string Name => "Vest";

		public Money Price => new Money(0, 0, 30);

		public override string ToString() => Lng.Elem("Vest");
	}
}
