using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class NailDozens
	{
		public string Name => "Nail, dozens";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Nail, dozens");
	}
}
