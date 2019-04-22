using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Debauchery
{
	class AlidariWoman
	{
		public string Name => "Alidari woman";

		public Money Price => new Money(30000, 0, 0);

		public override string ToString() => Lng.Elem("Alidari woman");
	}
}
