using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Accomodation
{
	class Bath
	{
		public string Name => "Bath";

		public Money Price => new Money(0, 0, 3);

		public override string ToString() => Lng.Elem("Bath");
	}
}
