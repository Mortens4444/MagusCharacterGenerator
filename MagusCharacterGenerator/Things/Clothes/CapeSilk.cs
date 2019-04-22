using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class CapeSilk
	{
		public string Name => "Cape, silk";

		public Money Price => new Money(2, 0, 0);

		public override string ToString() => Lng.Elem("Cape, silk");
	}
}
