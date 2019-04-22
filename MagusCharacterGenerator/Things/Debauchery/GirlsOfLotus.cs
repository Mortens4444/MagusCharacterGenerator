using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Debauchery
{
	class GirlsOfLotus
	{
		public string Name => "Girls of Lotus";

		public Money Price => new Money(1, 0, 0);

		public override string ToString() => Lng.Elem("Girls of Lotus");
	}
}
