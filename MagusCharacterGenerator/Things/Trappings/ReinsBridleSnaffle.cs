using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class ReinsBridleSnaffle
	{
		public string Name => "Reins, bridle, snaffle";

		public Money Price => new Money(0, 0, 15);

		public override string ToString() => Lng.Elem("Reins, bridle, snaffle");
	}
}
