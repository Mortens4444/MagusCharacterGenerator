using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class FireSteel
	{
		public string Name => "Fire steel";

		public Money Price => new Money(0, 0, 10);

		public override string ToString() => Lng.Elem("Fire steel");
	}
}
