using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class OldWineFromPredoc2Clusters
	{
		public string Name => "Old wine from Predoc 2 clusters";

		public Money Price => new Money(0, 0, 50);

		public override string ToString() => Lng.Elem("Old wine from Predoc 2 clusters");
	}
}
