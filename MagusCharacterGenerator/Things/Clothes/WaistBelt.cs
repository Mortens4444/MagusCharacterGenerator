using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class WaistBelt
	{
		public string Name => "Waist belt";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Waist belt");
	}
}
