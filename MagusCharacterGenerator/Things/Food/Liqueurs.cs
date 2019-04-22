using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class Liqueurs
	{
		public string Name => "Liqueurs";

		public Money Price => new Money(0, 0, 6);

		public override string ToString() => Lng.Elem("Liqueurs");
	}
}
