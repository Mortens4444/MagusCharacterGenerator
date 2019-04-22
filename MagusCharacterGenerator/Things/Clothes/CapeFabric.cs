using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class CapeFabric
	{
		public string Name => "Cape, fabric";

		public Money Price => new Money(0, 1, 0);

		public override string ToString() => Lng.Elem("Cape, fabric");
	}
}
