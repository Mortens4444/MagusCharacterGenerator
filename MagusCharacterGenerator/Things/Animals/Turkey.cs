using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Turkey
	{
		public string Name => "Turkey";

		public Money Price => new Money(0, 0, 8);

		public override string ToString() => Lng.Elem("Turkey");
	}
}
