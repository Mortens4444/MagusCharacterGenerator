using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class CastIronFootedBowl
	{
		public string Name => "Cast iron footed bowl";

		public Money Price => new Money(0, 0, 10);

		public override string ToString() => Lng.Elem("Cast iron footed bowl");
	}
}
