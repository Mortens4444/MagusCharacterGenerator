using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class CapeFur
	{
		public string Name => "Cape, fur";

		public Money Price => new Money(5, 0, 0);

		public override string ToString() => Lng.Elem("Cape, fur");
	}
}
