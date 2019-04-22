using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Quill
	{
		public string Name => "Quill";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Quill");
	}
}
