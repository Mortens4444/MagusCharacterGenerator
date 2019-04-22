using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Pantaloons
	{
		public string Name => "Pantaloons";

		public Money Price => new Money(0, 0, 150);

		public override string ToString() => Lng.Elem("Pantaloons");
	}
}
