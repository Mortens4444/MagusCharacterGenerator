using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Belt
	{
		public string Name => "Belt";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Belt");
	}
}
