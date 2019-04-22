using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class OldWineFromPredoc3Clusters
	{
		public string Name => "Old wine from Predoc 3 clusters";

		public Money Price => new Money(0, 1, 0);

		public override string ToString() => Lng.Elem("Old wine from Predoc 3 clusters");
	}
}
