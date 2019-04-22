using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Debauchery
{
	class OrdinaryProstitute
	{
		public string Name => "Ordinary prostitute";

		public Money Price => new Money(0, 3, 0);

		public override string ToString() => Lng.Elem("Ordinary prostitute");
	}
}
