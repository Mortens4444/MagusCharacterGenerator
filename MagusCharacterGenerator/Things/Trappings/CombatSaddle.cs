using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class CombatSaddle
	{
		public string Name => "Combat saddle";

		public Money Price => new Money(0, 5, 0);

		public override string ToString() => Lng.Elem("Combat saddle");
	}
}
