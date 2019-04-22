using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Tunic
	{
		public string Name => "Tunic";

		public Money Price => new Money(0, 3, 0);

		public override string ToString() => Lng.Elem("Tunic");
	}
}
