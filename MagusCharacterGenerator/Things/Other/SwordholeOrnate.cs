using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class SwordholeOrnate
	{
		public string Name => "Swordhole, ornate";

		public Money Price => new Money(0, 6, 0);

		public override string ToString() => Lng.Elem("Swordhole, ornate");
	}
}
