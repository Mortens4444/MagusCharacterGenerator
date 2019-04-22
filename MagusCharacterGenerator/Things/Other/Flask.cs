using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Flask
	{
		public string Name => "Flask";

		public Money Price => new Money(0, 0, 4);

		public override string ToString() => Lng.Elem("Flask");
	}
}
