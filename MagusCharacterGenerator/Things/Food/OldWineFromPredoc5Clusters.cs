using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class OldWineFromPredoc5Clusters
	{
		public string Name => "Old wine from Predoc 5 clusters";

		public Money Price => new Money(5, 0, 0);

		public override string ToString() => Lng.Elem("Old wine from Predoc 5 clusters");
	}
}
