using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class OldWineFromPredoc4Clusters
	{
		public string Name => "Old wine from Predoc 4 clusters";

		public Money Price => new Money(1, 0, 0);

		public override string ToString() => Lng.Elem("Old wine from Predoc 4 clusters");
	}
}
