using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class OldWineFromPredoc1Cluster
	{
		public string Name => "Old wine from Predoc 1 cluster";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Old wine from Predoc 1 cluster");
	}
}
