using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class EggsDozens
	{
		public string Name => "Eggs, dozens";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Eggs, dozens");
	}
}
