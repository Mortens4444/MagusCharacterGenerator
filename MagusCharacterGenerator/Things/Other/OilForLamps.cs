using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class OilForLamps
	{
		public string Name => "Oil for lamps";

		public Money Price => new Money(0, 0, 3);

		public override string ToString() => Lng.Elem("Oil for lamps");
	}
}
