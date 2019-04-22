using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Armors
{
	class Rag
	{
		public string Name => "Rag";

		public Money Price => new Money(0, 1, 0);

		public int MovementInhibitingFactor => 0;

		public int DamageSusceptiveValue => 1;

		public int Weight => 5;

		public override string ToString() => Lng.Elem("Rag");
	}
}
